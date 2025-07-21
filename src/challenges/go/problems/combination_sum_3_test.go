// https://leetcode.com/problems/combination-sum-iii

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type CombinationSum3 struct{}

func TestCombinationSum3(t *testing.T) {
	gen := core.TestSuite[CombinationSum3]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(3).Param(7).Result([][]int{{1,2,4}})
	}).Add(func(tc *core.TestCase) {
		tc.Param(3).Param(9).Result([][]int{{1,2,6},{1,3,5},{2,3,4}})
	}).Add(func(tc *core.TestCase) {
		tc.Param(4).Param(1).Result([][]int{})
	}).Run(t)
}

func (CombinationSum3) Solution(k int, n int) [][]int {
    result := [][]int{}

    var search func(int, int, *[]int) 
    search = func(current int, sum int, temp *[]int) {
        if len(*temp) == k {
            if sum == n {
                result = append(result, append([]int{}, (*temp)...))
            }

            return
        }

        for i := current; i <= 9; i++ {
            *temp = append(*temp, i)
            search(i + 1, sum + i, temp)
            *temp = (*temp)[:len(*temp)-1]
        }
    }

    search(1, 0, &[]int{})

    return result
}
