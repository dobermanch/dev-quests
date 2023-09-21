// https://leetcode.com/problems/merge-sorted-array/
package problems

import "testing"

func TestMerge(t *testing.T) {
	Merge([]int{1, 2, 3, 0, 0, 0}, 3, []int{2, 5, 6}, 3)
	//t.Log(result)
}

func Merge(nums1 []int, m int, nums2 []int, n int) {
	if n == 0 {
		return
	}

	i1, i2 := m-1, n-1
	for i := len(nums1) - 1; i >= 0; i-- {
		if i2 < 0 || (i1 >= 0 && nums1[i1] > nums2[i2]) {
			nums1[i] = nums1[i1]
			i1--
		} else {
			nums1[i] = nums2[i2]
			i2--
		}
	}
}

