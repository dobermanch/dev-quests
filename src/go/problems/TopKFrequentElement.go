// https://leetcode.com/problems/two-sum/

package problems

func TopKFrequentElement(nums []int, k int) []int {
	set := make(map[int]int)
	for _, v := range nums {
		set[v]++
	}

	bucket := make([][]int, len(nums)+1)
	for k, v := range set {
		bucket[v] = append(bucket[v], k)
	}

	result := []int{}
	for i := len(bucket) - 1; i >= 0; i-- {
		for j := 0; j < len(bucket[i]); j++ {
			result = append(result, bucket[i][j])
			if len(result) == k {
				return result
			}
		}
	}

	return result
}
