// https://leetcode.com/problems/group-anagrams/

package problems

func GroupAnagrams(strs []string) [][]string {
	set := make(map[string][]string)

	for _, str := range strs {
		hash := [26]byte{}
		for _, s := range str {
			hash[s-'a']++
		}

		key := string(hash[:])
		set[key] = append(set[key], str)
	}

	result := [][]string{}
	for _, v := range set {
		result = append(result, v)
	}

	return result
}
