#!/bin/bash

bash ./scripts/configure_pandas.sh
bash ./scripts/configure_mysql.sh

# install 
pip install requests markdownify