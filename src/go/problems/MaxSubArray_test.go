package problems

import "testing"

func TestMaxSubArray(t *testing.T) {
	result := MaxSubArray([]int{-2, 1, -3, 4, -1, 2, 1, -5, 4})
	t.Log(result)
}
