// https://leetcode.com/problems/majority-element/

package problems

import (
	"testing"
)

func TestMajorityElement(t *testing.T) {
	result := MajorityElement([]int{2, 2, 11, 2})
	t.Log(result)
}

func MajorityElement(nums []int) int {
	result := 0
	count := 0

	for _, num := range nums {
		if count == 0 {
			result = num
		}

		if result == num {
			count++
		} else {
			count--
		}
	}

	return result
}
