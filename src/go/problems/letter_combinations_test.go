// https://leetcode.com/problems/letter-combinations-of-a-phone-number

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type LetterCombinations struct{}

func TestLetterCombinations(t *testing.T) {
	gen := core.TestSuite[LetterCombinations]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("23").Result([]string{"ad","ae","af","bd","be","bf","cd","ce","cf"})
	}).Add(func(tc *core.TestCase) {
		tc.Param("").Result([]string{})
	}).Run(t)
}

func (LetterCombinations) Solution(digits string) string[] {
    set := [] string {
		"abc", "def",
		"ghi", "jkl", "mno",
		"pqrs", "tuv", "wxyz",
	};
    temp := make([]byte, len(digits))
	result := []string{}
	
	var search func(digits []byte, digitsIndex int, tempIndex int);
	search = func(digits []byte, digitsIndex int, tempIndex int){
		if digitsIndex >= len(digits) {
			result = append(result, string(temp))
			return
		}

		for i := 0; i < len(set[digits[digitsIndex] - '2']); i++ {
			temp[tempIndex] = set[digits[digitsIndex] - '2'][i]
			search(digits, digitsIndex + 1, tempIndex + 1);
		}
	}

	if len(digits) > 0 {
		search([]byte(digits), 0, 0);
	}

	return result
}
