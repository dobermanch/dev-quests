#!/bin/bash

# Rename files From PascaleCase to lowercase with underscore
# Example: LengthOfLongestSubstring.py --> length_of_longest_substring.py

path="$1"

if [[ -z $path ]]; then
    echo "The files path is not specified"
    exit -1
fi

path=${path%[ ]*}

echo "==="
echo "  Update files $path"
echo "==="

for file in $path/* ; do
    newFile=$(echo $file|sed -e 's/\([A-Z]\)/_\L\1/g' -e 's/^.\/_//')
    echo "$file => $newFile"
    mv "$file" "$newFile"
done