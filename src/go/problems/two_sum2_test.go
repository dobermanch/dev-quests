// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

package problems

import (
	"testing"
)

func TestTwoSum2(t *testing.T) {
	result := TwoSum2([]int{2, 7, 11, 15}, 9)
	t.Log(result)
}

func TwoSum2(numbers []int, target int) []int {
	start := 0
	end := len(numbers) - 1

	for start < end {
		sum := numbers[start] + numbers[end]

		if sum == target {
			break
		}

		if sum > target {
			end--
		} else {
			start++
		}
	}

	return []int{start + 1, end + 1}
}
