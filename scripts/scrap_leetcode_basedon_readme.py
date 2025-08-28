import re
import os
from typing import List, Dict
from scrap_leetcode_problem import scrap

SCRIPT_PATH = os.path.dirname(os.path.abspath(__file__))
ROOT_PATH = os.path.normpath(os.path.join(SCRIPT_PATH, ".."))
README_FILE = os.path.normpath(os.path.join(SCRIPT_PATH, "../README.md"))

lang_map = {
    "C#": "csharp",
    "Python": "python",
    "Go": "golang",
    "Rust": "rust",
    "JavaScript": "javascript",
    "TypeScript": "typescript",
    "MySQL": "mysql",
    "MsSQL": "mssql",
    "Pandas": "pythondata"
}

def parse_leetcode_markdown(md_text: str) -> List[Dict]:
    problem_blocks = re.findall(r"### \[(\d+)\. (.*?)\]\((https://leetcode\.com/problems/.*?)/?\)", md_text)
    code_blocks = re.findall(r"\*\*Solutions:\*\* \s*((?:\[`.*?`\]\(.*?\)\s*)+)", md_text)

    results = {}

    for (index, title, url), code_block in zip(problem_blocks, code_blocks):
        slug = url.rstrip("/").split("/")[-1]
        code_links = re.findall(r"\[`(.*?)`\]\((.*?)\)", code_block)

        entries = []
        for lang, path in code_links:
            if slug not in results:
                results[slug] = []

            results[slug].append({
                "slug": slug,
                "language": lang,
                "path": path
            })

    return results

def extract_solution_details(lang: str, content: str):
    patternClassName = None
    match lang.lower():
        case "csharp":
            patternClassName = r"\bclass\s+(\w+)"
        case "golang":
            patternClassName = r"\type\s+(\w+)"
        case "python":
            patternClassName = r"\bclass\s+(\w+)\s*\("

    if not patternClassName:
        return None

    className = re.search(patternClassName, content)
    url = re.search(r"https://\S+", content)
    if className:
        return {
            "class_name": className.group(1),
            "url": url.group(0) if url else ""
        }

    return None

def main():
    with open(README_FILE, "r", encoding="utf-8") as f:
        markdown_content = f.read()

    parsed = parse_leetcode_markdown(markdown_content)

    for slug, challenge in parsed.items():
        langs = [lang_map[entry['language']] for entry in challenge ]
        if not langs:
            print(f"🛑 Langs not found {slug}")

        scrap(slug, langs, False, None)

        continue

        for solution in challenge:
            fileName = os.path.join(ROOT_PATH, solution["path"][1:])
            if not os.path.exists(fileName):
                print(f"🛑 File does not exists {fileName}")
                continue

            lang = lang_map[solution['language']]
            if lang == "mssql":
                continue

            oldName = os.path.basename(fileName)
            newName = get_file_name(slug, lang)

            if not newName:
                print(f"🛑 Missed {lang} language for {slug} slug")
                continue

            # with open(fileName, "r", encoding="utf-8") as f:
            #     content = f.read()

            # details = extract_solution_details(lang, content)
            # if details:
            #     content = content.replace(details['class_name'], to_pascal_case(details['class_name']))
            #     if details['url']:
            #         content = content.replace(details['url'], f'https://leetcode.com/problems/{slug}')
            #     else:
            #         content = f'https://leetcode.com/problems/{slug}/n/n' + content

            #     with open(fileName, "w", encoding="utf-8") as f:
            #         f.write(content)
            #     print(f"✅ Updated content: {fileName}")

            if oldName != newName:
                newFileName = fileName.replace(oldName, newName)
                if os.path.exists(newFileName):
                    print(f"🛑 Cannot rename, file already exists: {slug} {fileName} → {newFileName}")
                    continue

                os.rename(fileName, newFileName)
                markdown_content = markdown_content.replace(oldName, newName)
                #print(f"✅ Renamed: {fileName} → {newFileName}")


    with open(README_FILE, "w", encoding="utf-8") as f:
        f.write(markdown_content)
        print(f"✅ Updated readme files")

def get_file_name(slug: str, lang: str) -> str:
    match lang.lower():
        case "csharp":
            return f'{to_pascal_case(slug)}.cs'
        case "python":
            return f'{to_snake_case(slug)}_test.py'
        case "pythondata":
            return f'{to_snake_case(slug)}_test.py'
        case "golang":
            return f'{to_snake_case(slug)}_test.go'
        case "rust":
            return f'{to_snake_case(slug)}_test.rs'
        case "javascript":
            return f'{to_camel_case(slug)}.js'
        case "typescript":
            return f'{to_camel_case(slug)}.ts'
        case "mysql":
            return f'{to_pascal_case(slug)}.sql'
        case "mssql":
            return f'{to_pascal_case(slug)}.sql'

    return None

def to_pascal_case(slug: str) -> str:
    return "".join([p[0].upper() + p[1:] for p in slug.split('-')])

def to_camel_case(slug: str) -> str:
    fileName = "".join([p[0].upper() + p[1:] for p in slug.split('-')])
    return fileName[0].lower() + fileName[1:]

def to_snake_case(slug: str) -> str:
    return slug.replace('-', '_')

if __name__ == "__main__":
    main()