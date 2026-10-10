#!/bin/bash

bash ./scripts/configure_pandas.sh
bash ./scripts/configure_mysql.sh

# install 
pip install requests markdownify

# Language server for Claude Code's csharp-lsp plugin (.claude/settings.json)
dotnet tool install --global csharp-ls