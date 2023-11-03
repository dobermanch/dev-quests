#!/bin/bash
# Updates Tags sections in the README.md file
# Example: Code: [C#](...) | [Go](...) | [Python](...)  --> Code: [`C#`](...) [`Go`](...) [`Python`](...)  
# Example: Tags: Array, Hash Table   --> Tags: `Array` `Hash Table`  

shopt -s extglob

file_path=$1

prefixMatch=$2

if [[ -z $file_path ]]; then
    echo "The README.md file path is not specified"
    exit -1
fi

if [[ -z $prefixMatch ]]; then
    echo "The update type is not specified. Supported: Code, Tags"
    exit -1
fi

if [[ $prefixMatch != "Tags" || $prefixMatch != "Code" ]]; then
    echo "The update type is not supported. Supported: Code, Tags"
    exit -1
fi

echo "==="
echo "  Update $prefixMatch section in $file_path file"
echo "==="

# The regex pattern
pattern="(^$prefixMatch:.*$)"

# Extract the regex group
groups=$(sed -nE "s/$pattern/\1/p" "$file_path")
IFS=$'\n' read -rd '' -a groups <<< "$groups"

for group in "${groups[@]}"; do
    # Split string by specified separators into an array    
    if [[ "$prefixMatch" = "Code" ]]; then
        pattern='|:'
    else
        pattern=',\`:'
    fi

    IFS=$pattern read -ra rawParts <<< "$group"

    # Cleanup and prepare parts
    parts=()
    for part in "${rawParts[@]}"; do
        # Remove the trailing and leading spaces
        part=("${part/#*( )/}") 
        part=("${part/%*( )/}") 
        
        if [[ -z "$part" || "$part" = "$prefixMatch" ]]; then
            continue
        fi

        if [[ "$prefixMatch" = "Code" ]]; then
            langPattern="\[([^\`\|\[]*)\]"
            part="$(echo $part | sed -E "s|$langPattern|[\`\1\`]|g")"
        else
            part="\`$part\`"
        fi

        parts+=("$part")
    done

    # Format final string
    formatted="$prefixMatch: $(printf "%s " "${parts[@]}") "

    # Escape characters for sed command
    group="$(echo $group | sed -e 's/[]\/$*.^|()[]/\\&/g')"
    formatted="$(echo $formatted | sed -e 's/[]\/$*.^()[]/\\&/g')"

    # Replace original match with modified
    sed -i -E "s/$group/$formatted/g" "$file_path"
done

