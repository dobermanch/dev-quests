// https://leetcode.com/problems/palindrome-number

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type IsPalindromeNumber struct{}
func TestIsPalindromeNumber(t *testing.T) {
	gen := core.TestSuite[IsPalindromeNumber]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(121).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param(-121).Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param(10).Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1221).Result(true)
	}).Run(t)
}

func (IsPalindromeNumber) Solution1(x int) bool {
	if x < 0 {
		return false
	}

	original := x
	reversed := 0

	for x > 0 {
		reversed = reversed * 10 + x % 10
		x = x / 10
	}

	return original == reversed
}

func (IsPalindromeNumber) Solution2(x int) bool {
	if x < 0 {
		return false
	}

	arr := []int{}

	for x > 0 {
		arr = append(arr, x % 10)
		x = x / 10
	}

	left := 0
	right := len(arr) - 1
	for left <= right {
		if arr[left] != arr[right] {
			return false
		}

		left++
		right--
	}

	return true
}