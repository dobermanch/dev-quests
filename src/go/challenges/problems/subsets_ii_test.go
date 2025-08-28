// https://leetcode.com/problems/subsets-ii/

package problems

import (
	"sort"
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type SubsetsWithDup struct{}

func TestSubsetsWithDup(t *testing.T) {
	gen := core.TestSuite[SubsetsWithDup]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,2}).Result([][]int{{},{1},{1,2},{1,2,2},{2},{2,2}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0}).Result([][]int{{},{0}})
	}).Run(t)
}

func (SubsetsWithDup) Solution(nums []int) [][]int {
	search := func(nums []int, index int, temp []int, result *[][]int) {
		tempCopy := make([]int, len(temp))
		copy(tempCopy, temp)
		*result = append(*result, tempCopy)
	
		for i := index; i < len(nums); i++ {
			if i > index && nums[i] == nums[i - 1] {
				continue
			}
	
			temp = append(temp, nums[i])
			search(nums, i+1, temp, result)
			temp = temp[:len(temp)-1]
		}
	}

	result := [][]int{}

	sort.Ints(nums)

	search(nums, 0, []int{}, &result)

	return result
}
