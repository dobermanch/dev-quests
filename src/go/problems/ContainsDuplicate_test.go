//https://leetcode.com/problems/contains-duplicate/

package problems

import "testing"

func TestContainsDuplicate(t *testing.T) {
	result := ContainsDuplicate([]int{-3, 4, 3, -2, -4, 2})
	t.Log(result)
}

func ContainsDuplicate(nums []int) bool {
	set := make(map[int]struct{})

	for i := 0; i < len(nums); i++ {
		if _, ok := set[nums[i]]; ok {
			return true
		}

		set[nums[i]] = struct{}{}
	}

	return false
}
