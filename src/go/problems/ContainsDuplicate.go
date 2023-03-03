//https://leetcode.com/problems/contains-duplicate/

package problems

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
