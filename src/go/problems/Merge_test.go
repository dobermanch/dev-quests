package problems

import "testing"

func TestMerge(t *testing.T) {
	result := Merge([]int{1, 2, 3, 0, 0, 0}, 3, []int{2, 5, 6}, 3)
	t.Log(result)
}
