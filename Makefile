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

DOTNET_SLN=./src/csharp/Challenges.slnx
DOTNET_TEST_PROJ=./src/csharp/challenges/Challenges.Tests.csproj
.PHONY: dotnet_build
dotnet_build:
	# Build .NET solution
	dotnet build $(DOTNET_SLN)

# Usage:
#   make dotnet_test                                  - run all tests
#   make dotnet_test TEST=NumBusesToDestination       - run tests whose name contains TEST
#   make dotnet_test FILTER="FullyQualifiedName=..."  - run tests matching a raw dotnet filter expression
TEST=
FILTER=
.PHONY: dotnet_test
dotnet_test:
	# Run .NET tests (roll forward so net9.0 tests run on a newer installed runtime)
	DOTNET_ROLL_FORWARD=Major dotnet test $(DOTNET_TEST_PROJ) \
		$(if $(TEST),--filter "FullyQualifiedName~$(TEST)") \
		$(if $(FILTER),--filter "$(FILTER)")
