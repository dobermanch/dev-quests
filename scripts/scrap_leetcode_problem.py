import re
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

            langSlug = langSlug.replace("3", "")
            path = get_lang_path(langSlug, slug)
            if path:
                code_snippets[langSlug] = Lang(
                    name=snippet["lang"].replace("3", ""),
                    slug=langSlug,
                    code=snippet["code"],
                    path=path
                )

        testcases = []
        sampleParams = data.get("sampleTestCase").split('\n')
        if len(sampleParams) > 0:
            params = data.get("exampleTestcases", '').split('\n')
            testcase = f"{params[0]}"
            for i in range(1, len(params)):
                if i % len(sampleParams) == 0:
                    testcases.append(testcase)
                    testcase = f"{params[i]}"
                else:
                    testcase += f" | {params[i]}"
            
            if testcase:
                testcases.append(testcase)

        return ProblemInfo(
            slug=slug,
            id=data["questionFrontendId"],
            title=data["title"],
            difficulty=data["difficulty"],
            content=data["content"],
            topic_tags=[tag["name"] for tag in data.get("topicTags", [])],
            code_snippets=code_snippets,
            example_testcases=testcases,
            sample_testcase=data.get("sampleTestCase")
        )
    else:
        raise ValueError("Failed to fetch problem data")

def generate_markdown(problem: ProblemInfo, output_dir: str):
    link = f"https://leetcode.com/problems/{problem.slug}/"
    md = f"# [{problem.id}. {problem.title}]({link})\n\n"

    md += f"**Difficulty:** `{problem.difficulty}`  \n"
    md += f"**Topics:** {' '.join([f'`{tag}`' for tag in problem.topic_tags])}  \n"

    langs = ' '.join([f'[`{lang.name}`]({os.path.relpath(lang.path, start=output_dir)})' for lang in problem.code_snippets.values()])
    md += f"**Solutions:** {langs}  \n\n"

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
            f.write(get_code_snippet(problem, lang.slug))

        print(f"✅ Generated {lang.name} file: {lang.path}")

def get_lang_path(lang: str, slug: str) -> str:
    match lang.lower():
        case "csharp":
            fileName = to_pascal_case(slug)
            return f"{os.path.join(SRC_PATH, 'csharp/challenges/Problems', f'{fileName}.cs')}"
        case "python":
            fileName = to_snake_case(slug)
            return f"{os.path.join(SRC_PATH, 'python/challenges/problems', f'{fileName}_test.py')}"
        case "pythondata":
            fileName = to_snake_case(slug)
            return f"{os.path.join(SRC_PATH, 'python/challenges/problems/pandas', f'{fileName}_test.py')}"
        case "golang":
            fileName = to_snake_case(slug)
            return f"{os.path.join(SRC_PATH, 'go/challenges/problems', f'{fileName}_test.go')}"
        case "rust":
            fileName = to_snake_case(slug)
            return f"{os.path.join(SRC_PATH, 'rust/challenges/src/problems', f'{fileName}_test.rs')}"
        case "javascript":
            fileName = to_camel_case(slug)
            return f"{os.path.join(SRC_PATH, 'javascript/challenges', f'{fileName}.js')}"
        case "typescript":
            fileName = to_camel_case(slug)
            return f"{os.path.join(SRC_PATH, 'typescript/challenges/problems', f'{fileName}.ts')}"
        case "mysql":
            fileName = to_pascal_case(slug)
            return f"{os.path.join(SRC_PATH, 'sql/challenges', f'{fileName}.sql')}"
        case "mssql":
            fileName = to_pascal_case(slug)
            return f"{os.path.join(SRC_PATH, 'sql/challenges', f'{fileName}.sql')}"

    return None

def get_code_snippet(problem: ProblemInfo, lang: str) -> str:
    snippet = problem.code_snippets[lang]

    match lang.lower():
        case "csharp":
            info = parse_method_signature(snippet.code, r'public\s+(?P<return_type>[^\s]+(?:<[^>]+>)?)\s+(?P<method_name>\w+)\s*\((?P<params>[^)]*)\)')
            template = """
// https://leetcode.com/problems/{slug}

namespace LeetCode.Problems;

public sealed class {name} : ProblemBase
{{
    [Theory]
    [ClassData(typeof({name}))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => 
/*
Test cases
{samples}
*/
          )
        ;

    private {return_type} Solution({params})
    {{
        // Solution is here
    }}
}}
"""
            return template.format(slug=problem.slug, name=to_pascal_case(problem.slug), params=info['parameters'], return_type=info['return_type'], samples='\n'.join(problem.example_testcases))
        case "python":
            info = parse_method_signature(snippet.code, r'def\s+(?P<method_name>\w+)\s*\((?P<params>[^)]*)\)\s*->\s*(?P<return_type>[^\s:]+)')
            template = """
# https://leetcode.com/problems/{slug}

from typing import List
from core.problem_base import *

class {name}(ProblemBase):
    def Solution({params}) -> {return_type}:
        # Solution is here

if __name__ == '__main__':
    TestGen({name}) \\
        .Add(lambda tc: Test cases here ) \\
        .Run()

# Test cases
{samples}
"""
            return template.format(slug=problem.slug, name=to_pascal_case(problem.slug), params=info['parameters'], return_type=info['return_type'], samples='\n'.join(f'# {test}' for test in problem.example_testcases))
        case "pythondata":
            info = parse_method_signature(snippet.code, r'def\s+(?P<method_name>\w+)\s*\((?P<params>[^)]*)\)\s*->\s*(?P<return_type>[^\s:]+)')
            template = """
# https://leetcode.com/problems/{slug}

import pandas as pd
from models.data_frame import *
from core.problem_base import *

class {name}(ProblemBase):
    def Solution(self, {params}) -> {return_type}:
        # Solution is here

if __name__ == '__main__':
    TestGen({name}) \\
        .Add(lambda tc: Test Cases here ) \\
        .Run()

# Test cases
{samples}
"""
            return template.format(slug=problem.slug, name=to_pascal_case(problem.slug), params=info['parameters'], return_type=info['return_type'], samples='\n'.join(f'# {test}' for test in problem.example_testcases))
        case "golang":
            info = parse_method_signature(snippet.code, r'func\s+(?P<method_name>\w+)\s*\((?P<params>[^)]*)\)\s*(?P<return_type>\[\[.*?\]\]|\[\].*?\w+|\w+)?\s*\{')
            template = """
// https://leetcode.com/problems/{slug}

package problems

import (
    "testing"
    "github.com/dobermanch/leetcode/core"
)

type {name} struct{{}}

func Test{name}(t *testing.T) {{
    gen := core.TestSuite[{name}]{{}}
    gen.Add(func(tc *core.TestCase) {{

// Test cases here
{samples}

    }}).Run(t)
}}

func ({name}) Solution({params}) {return_type} {{
    // Solution is here
}}
"""
            return template.format(slug=problem.slug, name=to_pascal_case(problem.slug), params=info['parameters'], return_type=info['return_type'], samples='\n'.join(f'// {test}' for test in problem.example_testcases))
        case "rust":
            info = parse_method_signature(snippet.code, r'pub\s+fn\s+(?P<method_name>\w+)\s*\((?P<params>[^)]*)\)\s*->\s*(?P<return_type>[^{\n]+)')
            template = """
// https://leetcode.com/problems/{slug}

pub fn solution({params}) -> {return_type} {{
// Solution is here
}}

// Test cases
{samples}
"""
            return template.format(slug=problem.slug, name=to_pascal_case(problem.slug), params=info['parameters'], return_type=info['return_type'], samples='\n'.join(f'// {test}' for test in problem.example_testcases))
        case "javascript":
            template = """
// https://leetcode.com/problems/{slug}

{snippet}

// Test cases
{samples}
"""
            return template.format(slug=problem.slug, snippet=snippet.code, samples='\n'.join(f'// {test}' for test in problem.example_testcases))
        case "typescript":
            template = """
// https://leetcode.com/problems/{slug}

{snippet}

// Test cases
{samples}
"""
            return template.format(slug=problem.slug, snippet=snippet.code, samples='\n'.join(f'// {test}' for test in problem.example_testcases))
        case "mysql":
            template = """
/* https://leetcode.com/problems/{slug} */

{snippet}

/*
Test Cases
{samples}
*/
"""
            return template.format(slug=problem.slug, snippet=snippet.code, samples='\n'.join(problem.example_testcases))
        case "mssql":
            template = """
/* https://leetcode.com/problems/{slug} */

{snippet}

/*
Test Cases
{samples}
*/
"""
            return template.format(slug=problem.slug, snippet=snippet.code, samples='\n'.join(problem.example_testcases))

def parse_method_signature(code: str, pattern: str):
    match = re.search(pattern, code)
    if not match:
        return None

    return {
        "return_type": match.group("return_type"),
        "method_name": match.group("method_name"),
        "parameters": match.group("params")
    }


def to_pascal_case(slug: str) -> str:
    return "".join([p[0].upper() + p[1:] for p in slug.split('-')])

def to_camel_case(slug: str) -> str:
    fileName = "".join([p[0].upper() + p[1:] for p in slug.split('-')])
    return fileName[0].lower() + fileName[1:]

def to_snake_case(slug: str) -> str:
    return slug.replace('-', '_')

def file_exists_with_slug(slug: str, output_dir: str) -> bool:
    for filename in os.listdir(output_dir):
        if filename.endswith(f"-{slug}.md"):
            return True
    return False

def main():
    parser = argparse.ArgumentParser(description="Export LeetCode problem description to Markdown")
    parser.add_argument("slug", help="LeetCode problem slug (e.g., 'two-sum')")
    parser.add_argument("--output_dir", default=OUTPUT_DIR, help=f"Directory to save the Markdown file (default: {OUTPUT_DIR})")
    parser.add_argument("--langs", default=None, help=f"List of the solution languages separated by comma (e.g., 'csharp,python,rust,typescript,javascript,mysql')")
    parser.add_argument("--gen_langs", default=False, help=f"Generate solution files for provided languages")

    args = parser.parse_args()
    langs = [lang.strip().lower() for lang in args.langs.split(',')] if args.langs else []

    scrap(args.slug, langs, args.gen_langs, args.output_dir)

def scrap(slug: str, langs: List[str], generate_langs: bool, output_dir: str):
    if not output_dir:
        output_dir = OUTPUT_DIR

    # if file_exists_with_slug(slug, output_dir):
    #     print(f"🛑 Already exists {slug}")
    #     return

    for index in range(len(langs)):
        if langs[index] == "python":
            langs[index] = "python3"

    problem_data = fetch_leetcode_problem(slug, langs)

    generate_markdown(problem_data, output_dir)

    if generate_langs:
        generate_lang_files(problem_data)

if __name__ == "__main__":
    main()