// https://leetcode.com/problems/two-sum/
package problems

import "testing"

func TestTwoSum(t *testing.T) {
    result := TwoSum([]int{2,7,11,15}, 9)
    t.Log(result)
}

func TwoSum(nums []int, target int) []int {
    set := make(map[int]int, len(nums))

    for i, n := range nums {
        if v, ok := set[target - n]; ok {
            return []int{v, i}
        }

        set[n] = i
    }

    return []int{}
}