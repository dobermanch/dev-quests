all:

.PHONY: tags
tags: 
	# Update tags section in README.md
	./scripts/update_readme.sh "README.md" "Tags"

.PHONY: code
code: 
	# Update code section in README.md
	./scripts/update_readme.sh "README.md" "Code"

path=""
.PHONY: rename_files
rename_files:
	# Rename files
	./scripts/rename_files.sh $(path)

.PHONY: configure_sql
configure_sql:
	# Configure MySQL
	./scripts/configure_mysql.sh

.PHONY: configure_pandas
configure_pandas:
	# Configure Pandas
	./scripts/configure_pandas.sh

SLUG=
LANGS=
.PHONY: challenge
challenge:
	# Scrap Leetcode problem
	python ./scripts/scrap_leetcode_problem.py $(SLUG) --output_dir ${PWD}/docs/challenges --langs $(LANGS) --gen_langs true
	python ./scripts/generate_readme.py --output_dir ${PWD}/docs/challenges