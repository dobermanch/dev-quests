// https://leetcode.com/problems/subsets/

package problems

import "testing"

func TestSubsets(t *testing.T) {
	result := Subsets([]int{1, 2, 3, 4})
	t.Log(result)
}

func Subsets(nums []int) [][]int {
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
