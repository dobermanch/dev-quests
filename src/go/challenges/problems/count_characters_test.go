// https://leetcode.com/problems/find-words-that-can-be-formed-by-characters

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type CountCharacters struct{}

func TestCountCharacters(t *testing.T) {
	gen := core.TestSuite[CountCharacters]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"cat","bt","hat","tree"}).Param("atach").Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"hello","world","leetcode"}).Param("welldonehoneyr").Result(10)
	}).Run(t)
}

func (CountCharacters) Solution(words []string, chars string) int {
    charMap := make([]int, 26)

	for _, ch := range chars {
		charMap[ch - 'a']++
	}

	result := 0
	for _, word := range words {
		wordMap := make([]int, 26)
		matched := true

		for _, ch := range word {
			wordMap[ch - 'a']++

			if wordMap[ch - 'a'] > charMap[ch - 'a'] {
				matched = false
				break
			}
		}

		if matched {
			result += len(word)
		}
	}

	return result
}
