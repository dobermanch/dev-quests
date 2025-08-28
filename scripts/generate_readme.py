import re
import os
import argparse
from typing import Dict, List

SCRIPT_PATH = os.path.dirname(os.path.abspath(__file__))
OUTPUT_DIR = os.path.normpath(os.path.join(SCRIPT_PATH, "../docs/challenges"))

def generate_readme(output_dir: str):
    challenges = []
    difficulties = {}
    for filename in os.listdir(output_dir):
        if filename == "README.md":
            continue

        with open(os.path.join(output_dir, filename), "r", encoding="utf-8") as f:
            markdown_content = f.read()

        challenge = parse_leetcode_markdown(markdown_content)
        challenge['file'] = filename
        challenges.append(challenge)

        difficulty = challenge['difficulty'].strip(' ').strip('`')
        difficulties[difficulty] = difficulties.get(difficulty, 0) + 1

    challenges = sorted(challenges, key=lambda it: it["index"])

    md = "# Overview\n\n"
    md += "A collection of my solutions to diverse [LeetCode](https://leetcode.com/SergiiCh/) problems.  \n\n"

    md += "**Solved challenges**  \n\n"
    md += "| Difficulty | Count |\n|---:|---:|\n"
    for key, value in difficulties.items():
        md += f"| {key} | {value} |\n"
    md += f"| **Total** | {len(challenges)} |\n"
    md += "\n"

    md += "## Challenges  \n\n"
    md += "| ID | Name | Difficulty | Topics | Solutions |\n|:---:|---|:---:|---|---|\n"

    for _, challenge in enumerate(challenges):
        md += f"| {challenge['index']} | [{challenge['title']}]({challenge['file']}) | {challenge['difficulty']} | {challenge['topics']} | {challenge['solutions']} |\n"


    filepath = os.path.join(output_dir, "README.md")

    with open(filepath, "w", encoding="utf-8") as f:
        f.write(md)

    print(f"✅ Generated README file: {filepath}")

def parse_leetcode_markdown(md_text: str) -> List[Dict]:
    problem_blocks = re.findall(r"# \[(\d+)\. (.*?)\]\((https://leetcode\.com/problems/.*?)/?\)", md_text)
    difficulty_blocks = re.findall(r"\*\*Difficulty:\*\*\s*((?:`[^`]+`\s*)+)", md_text)
    topics_blocks = re.findall(r"\*\*Topics:\*\*\s*((?:`[^`]+`\s*)+)", md_text)
    solutions_blocks = re.findall(r"\*\*Solutions:\*\* \s*((?:\[`.*?`\]\(.*?\)\s*)+)", md_text)

    return {
        "index": int(problem_blocks[0][0]),
        "title": problem_blocks[0][1],
        "url": problem_blocks[0][2],
        "topics": topics_blocks[0].strip("\n") if topics_blocks else "",
        "solutions": solutions_blocks[0].strip("\n") if solutions_blocks else "",
        "difficulty": difficulty_blocks[0].strip("\n") if difficulty_blocks else ""
    }

def main():
    parser = argparse.ArgumentParser(description="Generate README.md based on challenges md files")
    parser.add_argument("--output_dir", default=OUTPUT_DIR, help=f"Directory to save the Markdown file (default: {OUTPUT_DIR})")

    args = parser.parse_args()
    
    generate_readme(args.output_dir)

if __name__ == "__main__":
    main()