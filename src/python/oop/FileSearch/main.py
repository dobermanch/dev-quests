from search import *
import argparse

def main():
    # search . -r -s -p "(name = 'match_criteria' and ext = 'py') or size = 787"
    # . : current dir
    # -r: recursive
    # -s: case-sensitive
    # -p: predicate

    parser = argparse.ArgumentParser(description="Search files")
    parser.add_argument("pos_path", nargs="?", type=str, help="Search folder")
    parser.add_argument("--path", type=str, help="Search folder")
    parser.add_argument("-r", "--recursive", action="store_true", help="Search recursively")
    parser.add_argument("-s", "--case", action="store_true", help="Match strings case sensitive")

    args = parser.parse_args()

    path = args.pos_path or args.path
    search = SearchEngine(path)

    files = search.search(
        OrOperand([
            BySizeMatchCriteria(787),
            AndOperand([
                ByNameMatchCriteria("Predicate_base"),
                ByExtensionMatchCriteria("py"),
            ])
        ]),
        SearchOptions(args.recursive, args.case)
    )

    print(f"Found {len(files)} files:")
    for file in files:
        print(f"  {file.path}")

    print(f"Done")

if __name__ == "__main__":
    main()