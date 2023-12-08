// https://leetcode.com/problems/rotate-array

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Rotate struct{}

func TestRotate(t *testing.T) {
	gen := core.TestSuite[Rotate]{}
	gen.Run(t)
}

func (Rotate) Solution(nums []int, k int) []int {
	index := 0
	prev := nums[index]
	visited := 0
	count := 0
	length := len(nums)
	for count < length {
		count++
		index += k
		if index >= length {
			index %= length
		}

		nums[index], prev = prev, nums[index]

		if index == visited && index < length - 1 {
			visited++
			index++
			prev = nums[index]
		}
	}

	return nums
}
