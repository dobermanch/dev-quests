// https://leetcode.com/problems/two-sum/

package problems

func Merge(nums1 []int, m int, nums2 []int, n int) []int {
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

	return nums1
}
