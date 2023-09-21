// https://leetcode.com/problems/longest-consecutive-sequence/

package problems

import "testing"

func TestLongestConsecutive(t *testing.T) {
	result := LongestConsecutive([]int{100, 4, 200, 1, 3, 2})
	t.Log(result)
}

func LongestConsecutive(nums []int) int {
	set := map[int]struct{}{}
	max := 0

	for i := 0; i < len(nums); i++ {
		set[nums[i]] = struct{}{}
	}

	for key := range set {
		if _, ok := set[key-1]; ok {
			continue
		}

		count := 1
		for {
			if _, ok := set[key+count]; !ok {
				break
			}
			count++
		}

		if max < count {
			max = count
		}
	}

	return max
}
