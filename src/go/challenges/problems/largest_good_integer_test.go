// https://leetcode.com/problems/largest-3-same-digit-number-in-string

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type LargestGoodInteger struct{}

func TestLargestGoodInteger(t *testing.T) {
	gen := core.TestSuite[LargestGoodInteger]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("6777133339").Result("777")
	}).Add(func(tc *core.TestCase) {
		tc.Param("2300019").Result("000")
	}).Add(func(tc *core.TestCase) {
		tc.Param("42352338").Result("")
	}).Run(t)
}

func (LargestGoodInteger) Solution(num string) string {
	var result byte = ' '
	var digit  = num[0]
	count := 1;
	for i := 1; i < len(num); i++ {
		if num[i] != digit {
			digit = num[i]
			count = 1
			continue
		}

		count++
		if count >= 3 && digit > result {
			result = digit
		}
	}

	if result == ' ' {
		return ""
	}

	return strings.Repeat(string(result), 3)
}
