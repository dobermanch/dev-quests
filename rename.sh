#!/bin/bash

# Rename files From PascaleCase to lowercase with underscore
# Example: LengthOfLongestSubstring.py --> length_of_longest_substring.py

for file in ./* ; do
    mv "$file" "$(echo $file|sed -e 's/\([A-Z]\)/_\L\1/g' -e 's/^.\/_//')"
done