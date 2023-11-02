#!/bin/bash
# Updates Tags sections in the README.md file
# Example: Tags: Array, Hash Table   --> Tags: `Array` `Hash Table`  

shopt -s extglob

file_path=README.md

tagsMatch="Tags"

# The regex pattern
pattern="(^$tagsMatch:.*$)"

# Extract the regex group
groups=$( sed -nE "s/$pattern/\1/p" "$file_path" )
IFS=$'\n' read -rd '' -a groups <<< "$groups"

for group in "${groups[@]}"; do
    # Split the by comma or by ` into an array
    IFS=',\`:' read -ra rawTags <<< "$group"

    # Cleanup and prepare tags
    tags=()
    for tag in "${rawTags[@]}"; do
        # Remove the trailing and leading spaces
        tag=("${tag/#*( )/}") 
        tag=("${tag/%*( )/}") 
        
        if [[ -z "$tag" || "$tag" = "$tagsMatch" ]]; then
            continue
        fi

        tags+=("$tag")
    done
    
    # Format tag string
    quoted_tags="$tagsMatch: $(printf "\`%s\` " "${tags[@]}") "

    # Replace original match with modified
    sed -i -E "s/$group/$quoted_tags/g" "$file_path"
done
