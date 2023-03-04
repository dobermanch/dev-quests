package problems

import "testing"

func TestGroupAnagrams(t *testing.T) {
	result := GroupAnagrams([]string{"eat", "tea", "tan", "ate", "nat", "bat"})
	t.Log(result)
}
