import requests
import os
import argparse
import markdownify
from dataclasses import dataclass
from typing import Dict, List, Optional

@dataclass
class Lang:
    name: str
    slug: str
    code: str
    path: str

@dataclass
class ProblemInfo:
    id: str
    title: str
    slug: str
    difficulty: str
    content: str
    topic_tags: List[str]
    code_snippets: Dict[str, Lang]
    example_testcases: List[str]
    sample_testcase: Optional[str]


SCRIPT_PATH = os.path.dirname(os.path.abspath(__file__))
OUTPUT_DIR = os.path.normpath(os.path.join(SCRIPT_PATH, "../docs/challenges"))
SRC_PATH = os.path.normpath(os.path.join(SCRIPT_PATH, "../src"))

def fetch_leetcode_problem(slug: str, supportedLangs: List[str]) -> dict:
    url = "https://leetcode.com/graphql"
    headers = {
        "Content-Type": "application/json",
        "Referer": f"https://leetcode.com/problems/{slug}/",
        "User-Agent": "Mozilla/5.0"
    }

    query = """
    query questionData($titleSlug: String!) {
      question(titleSlug: $titleSlug) {
        questionFrontendId
        title
        content
        difficulty
        topicTags {
          name
          slug
        }
        codeSnippets {
          lang
          langSlug
          code
        }
        exampleTestcases
        sampleTestCase
      }
    }
    """

    payload = {
        "query": query,
        "variables": {"titleSlug": slug}
    }

    response = requests.post(url, json=payload, headers=headers)
    data = response.json()

    if "data" in data and "question" in data["data"]:
        data = response.json()["data"]["question"]

        code_snippets={}

        for snippet in data.get("codeSnippets", []):
            langSlug = snippet["langSlug"]
            if langSlug not in supportedLangs:
                continue

            path = get_lang_path(langSlug, slug)
            if path:
                code_snippets[langSlug] = Lang(
                    name=snippet["lang"],
                    slug=langSlug,
                    code=snippet["code"],
                    path=path
                )

        return ProblemInfo(
            slug=slug,
            id=data["questionFrontendId"],
            title=data["title"],
            difficulty=data["difficulty"],
            content=data["content"],
            topic_tags=[tag["name"] for tag in data.get("topicTags", [])],
            code_snippets=code_snippets,
            example_testcases=data.get("exampleTestcases", []),
            sample_testcase=data.get("sampleTestCase")
        )
    else:
        raise ValueError("Failed to fetch problem data")

def generate_markdown(problem: ProblemInfo, output_dir: str):
    link = f"https://leetcode.com/problems/{problem.slug}/"
    md = f"# [{problem.id}. {problem.title}]({link})\n\n"

    md += f"**Difficulty:** {problem.difficulty}\n\n"
    md += f"**Topics:** {', '.join(problem.topic_tags)}\n\n"

    langs = ', '.join([f'[{lang.name}]({os.path.relpath(lang.path, start=output_dir)})' for lang in problem.code_snippets.values()])
    md += f"**Solutions:** {langs}\n\n"

    md += "---\n\n"
    md += markdownify.markdownify(problem.content, heading_style="ATX")

    os.makedirs(output_dir, exist_ok=True)
    filepath = os.path.join(output_dir, f"{problem.id}-{problem.slug}.md")

    with open(filepath, "w", encoding="utf-8") as f:
        f.write(md)

    print(f"✅ Generated markdown file: {filepath}")

def generate_lang_files(problem: ProblemInfo):
    for lang in problem.code_snippets.values():
        if os.path.exists(lang.path):
            continue

        filePath = os.path.normpath(lang.path)

        with open(filePath, "w", encoding="utf-8") as f:
            f.write(lang.code)

        print(f"✅ Generated {lang.name} file: {lang.path}")

def get_lang_path(lang: str, slug: str) -> str:
    match lang.lower():
        case "csharp":
            fileName = to_pascal_case(slug)
            return f"{os.path.join(SRC_PATH, 'csharp/challenges/Problems', f'{fileName}.cs')}"
        case "python":
            fileName = to_snake_case(slug)
            return f"{os.path.join(SRC_PATH, 'python/challenges/problems', f'{fileName}_test.py')}"
        case "golang":
            fileName = to_snake_case(slug)
            return f"{os.path.join(SRC_PATH, 'go/challenges/problems', f'{fileName}_test.go')}"
        case "rust":
            fileName = to_snake_case(slug)
            return f"{os.path.join(SRC_PATH, 'rust/challenges/src/problems', f'{fileName}_test.rs')}"
        case "javascript":
            fileName = to_camel_case(slug)
            return f"{os.path.join(SRC_PATH, 'javascript/challenges/problems', f'{fileName}.js')}"
        case "typescript":
            fileName = to_camel_case(slug)
            return f"{os.path.join(SRC_PATH, 'typescript/challenges/problems', f'{fileName}.ts')}"
        case "mysql":
            fileName = to_pascal_case(slug)
            return f"{os.path.join(SRC_PATH, 'sql/challenges', f'{fileName}.sql')}"

    return None

def to_pascal_case(slug: str) -> str:
    return "".join([p[0].upper() + p[1:] for p in slug.split('-')])

def to_camel_case(slug: str) -> str:
    fileName = "".join([p[0].upper() + p[1:] for p in slug.split('-')])
    return fileName[0].lower() + fileName[1:]

def to_snake_case(slug: str) -> str:
    return slug.replace('-', '_')

def main():
    parser = argparse.ArgumentParser(description="Export LeetCode problem description to Markdown")
    parser.add_argument("slug", help="LeetCode problem slug (e.g., 'two-sum')")
    parser.add_argument("--output_dir", default=OUTPUT_DIR, help=f"Directory to save the Markdown file (default: {OUTPUT_DIR})")
    parser.add_argument("--langs", default=None, help=f"List of the solution languages separated by comma (e.g., 'csharp,python,rust,typescript,javascript,mysql')")
    parser.add_argument("--gen_langs", default=False, help=f"Generate solution files for provided languages")

    args = parser.parse_args()

    langs = [lang.strip().lower() for lang in args.langs.split(',')] if args.langs else []

    problem_data = fetch_leetcode_problem(args.slug, langs)

    generate_markdown(problem_data, args.output_dir)

    if args.gen_langs:
        generate_lang_files(problem_data)

if __name__ == "__main__":
    main()