// https://leetcode.com/problems/subsets/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Subsets struct{}

func TestSubsets(t *testing.T) {
	gen := core.TestSuite[Subsets]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,3}).Result([][]int{{},{1},{2},{1,2},{3},{1,3},{2,3},{1,2,3}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{0}).Result([][]int{{},{0}})
	}).Run(t)
}

func (Subsets) Solution(nums []int) [][]int {
	result := [][]int{}

	search(nums, 0, []int{}, &result)

	return result
}

func search(nums []int, index int, temp []int, result *[][]int) {
	tempCopy := make([]int, len(temp))
	copy(tempCopy, temp)
	*result = append(*result, tempCopy)

	for i := index; i < len(nums); i++ {
		temp = append(temp, nums[i])
		search(nums, i+1, temp, result)
		temp = temp[:len(temp)-1]
	}
}
