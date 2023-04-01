package problems

import "testing"

func TestIsAnagram(t *testing.T) {
	result := IsAnagram("anagram", "nagaram")
	t.Log(result)
}
