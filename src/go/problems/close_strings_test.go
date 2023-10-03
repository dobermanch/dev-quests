// https://leetcode.com/problems/determine-if-two-strings-are-close

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type CloseStrings struct{}

func TestCloseStrings(t *testing.T) {
	gen := core.TestSuite[CloseStrings]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("abc").Param("bca").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("a").Param("aa").Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param("cabbba").Param("abbccc").Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param("abbzzca").Param("babzzcz").Result(false)
	}).Run(t)
}

func (CloseStrings) Solution(word1 string, word2 string) bool {
	if len(word1) != len(word2) {
		return false
	}

	count := func(word string) []int {
		set := make([]int, 26)
		for i := 0; i < len(word); i++ {
			set[word[i]-'a']++
		}
		return set
	}

	map1 := count(word1)
	map2 := count(word2)

	for i := 0; i < len(map1); i++ {
		if (map1[i] == 0 && map2[i] > 0) || (map1[i] > 0 && map2[i] == 0) {
			return false
		}
	}

	sort.Ints(map1)
	sort.Ints(map2)

	for i := 0; i < len(map1); i++ {
		if map1[i] != map2[i] {
			return false
		}
	}

	return true
}
