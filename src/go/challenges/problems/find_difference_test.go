// https://leetcode.com/problems/find-the-difference-of-two-arrays

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FindDifference struct{}

func TestFindDifference(t *testing.T) {
	gen := core.TestSuite[FindDifference]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3}).Param([]int{2, 4, 6}).Result([][]int{{1, 3}, {4, 6}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 3}).Param([]int{1, 1, 2, 2}).Result([][]int{{3}, {}})
	}).Run(t)
}

func (FindDifference) Solution(nums1 []int, nums2 []int) [][]int {
	createHash := func(nums []int) map[int]struct{} {
		set := map[int]struct{}{}
		for _, item := range nums {
			set[item] = struct{}{}
		}
		return set
	}

	filter := func(set1 map[int]struct{}, set2 map[int]struct{}) []int {
		result := []int{}
		for key := range set1 {
			if _, ok := set2[key]; !ok {
				result = append(result, key)
			}
		}
		return result
	}

	set1 := createHash(nums1)
	set2 := createHash(nums2)

	result := make([][]int, 2)
	result[0] = filter(set1, set2)
	result[1] = filter(set2, set1)

	return result
}
