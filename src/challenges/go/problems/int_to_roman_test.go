// https://leetcode.com/problems/integer-to-roman

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type IntToRoman struct{}

func TestIntToRoman(t *testing.T) {
	gen := core.TestSuite[IntToRoman]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(3).Result("III")
	}).Add(func(tc *core.TestCase) {
		tc.Param(58).Result("LVIII")
	}).Add(func(tc *core.TestCase) {
		tc.Param(1994).Result("MCMXCIV")
	}).Add(func(tc *core.TestCase) {
		tc.Param(3490).Result("MMMCDXC")
	}).Run(t)
}

func (IntToRoman) Solution(num int) string {
	set := map[int]string{
		1:    "I",
		5:    "V",
		10:   "X",
		50:   "L",
		100:  "C",
		500:  "D",
		1000: "M",
	}

	result := ""
	acc := 1
	for num > 0 {
		reminder := num % 10
		number := reminder * acc
		num /= 10

		switch {
		case reminder <= 3:
			result = strings.Repeat(set[acc], reminder) + result
		case reminder == 4:
			result = set[acc] + set[number+acc] + result
		case reminder > 5 && reminder <= 8:
			result = set[5*acc] + strings.Repeat(set[acc], reminder-5) + result
		case reminder == 9:
			result = set[acc] + set[acc*10] + result
		default:
			result = set[number] + result
		}

		acc *= 10
	}

	return result
}
