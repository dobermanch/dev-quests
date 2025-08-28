// https://leetcode.com/problems/merge-sorted-array/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Merge struct{}

func TestMerge(t *testing.T) {
	gen := core.TestSuite[Merge]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 0, 0, 0}).Param(3).Param([]int{2, 5, 6}).Param(3).Result([]int{1, 2, 2, 3, 5, 6})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1}).Param(1).Param([]int{}).Param(0).Result([]int{1})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0}).Param(0).Param([]int{1}).Param(1).Result([]int{1})
	}).Run(t)
}

func (Merge) Solution(nums1 []int, m int, nums2 []int, n int) {
	if n == 0 {
		return
	}

	i1, i2 := m-1, n-1
	for i := len(nums1) - 1; i >= 0; i-- {
		if i2 < 0 || (i1 >= 0 && nums1[i1] > nums2[i2]) {
			nums1[i] = nums1[i1]
			i1--
		} else {
			nums1[i] = nums2[i2]
			i2--
		}
	}
}
