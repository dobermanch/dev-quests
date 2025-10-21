// https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type KthSmallestElementInASortedMatrix struct{}

func TestKthSmallestElementInASortedMatrix(t *testing.T) {
	gen := core.TestSuite[KthSmallestElementInASortedMatrix]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1, 5, 9}, {10, 11, 13}, {12, 13, 15}}).Param(8).Result(13)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{-5}}).Param(1).Result(-5)
	}).Run(t)
}

func (KthSmallestElementInASortedMatrix) Solution(matrix [][]int, k int) int {
	n := len(matrix)
	left := matrix[0][0]
	right := matrix[n-1][n-1]
	result := right

	for left < right {
		mid := left + (right-left)/2
		target := 0

		for i := 0; i < n; i++ {
			if matrix[i][0] > mid {
				break
			}

			l, r := 0, n-1
			for l <= r {
				m := (l + r) / 2
				if matrix[i][m] <= mid {
					l = m + 1
				} else {
					r = m - 1
				}
			}
			target += l
		}

		if target < k {
			left = mid + 1
		} else {
			result = mid
			right = mid
		}
	}

	return result
}
