// https://leetcode.com/problems/merge-strings-alternately/

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MergeAlternately struct{}

func TestMergeAlternately(t *testing.T) {
	gen := core.TestSuite[MergeAlternately]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("abc").Param("pqr").Result("apbqcr")
	}).Add(func(tc *core.TestCase) {
		tc.Param("ab").Param("pqrs").Result("apbqrs")
	}).Add(func(tc *core.TestCase) {
		tc.Param("abcd").Param("pq").Result("apbqcd")
	}).Run(t)
}

func (MergeAlternately) Solution(word1 string, word2 string) string {
	word1Length := len(word1)
	word2Length := len(word2)
	length := word1Length
	
	if (word2Length > word1Length) {
		length = word2Length
	}

	var result strings.Builder

	for i := 0; i < length; i++ {
		if i < word1Length {
			result.WriteByte(word1[i])
		}

		if i < word2Length {
			result.WriteByte(word2[i])
		}
	}

	return result.String()
}
