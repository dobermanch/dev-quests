// https://leetcode.com/problems/group-anagrams/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type GroupAnagrams struct{}

func TestGroupAnagrams(t *testing.T) {
	gen := core.TestSuite[GroupAnagrams]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"eat", "tea", "tan", "ate", "nat", "bat"}).Result([][]string{{"bat"}, {"nat", "tan"}, {"ate", "eat", "tea"}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{""}).Result([][]string{{""}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"a"}).Result([][]string{{"a"}})
	}).Run(t)
}

func (GroupAnagrams) Solution(strs []string) [][]string {
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
