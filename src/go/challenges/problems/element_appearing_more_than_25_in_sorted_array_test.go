// https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type FindSpecialInteger struct{}

func TestFindSpecialInteger(t *testing.T) {
	gen := core.TestSuite[FindSpecialInteger]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,2,6,6,6,6,7,10}).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1,2,2,3,3,3,3}).Result(3)
	}).Run(t)
}

func (FindSpecialInteger) Solution1(arr []int) int {
	minCount := len(arr) / 4
	for i := 0; i < len(arr) - minCount; i++ {
		if arr[i] == arr[i + minCount] {
			return arr[i]
		}
	}

	return arr[0]
}

func (FindSpecialInteger) Solution2(arr []int) int {
	minCount := len(arr) / 4;
	count := 1
	for i := 1; i < len(arr); i++ {
		if arr[i - 1] == arr[i] {
			count++
		} else {
			count = 1
		}

		if count > minCount {
			return arr[i]
		}
	}

	return arr[0]
}

