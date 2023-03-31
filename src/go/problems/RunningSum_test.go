package problems

import "testing"

func TestRunningSum(t *testing.T) {
	result := RunningSum([]int{1, 2, 3, 4})
	t.Log(result)
}
