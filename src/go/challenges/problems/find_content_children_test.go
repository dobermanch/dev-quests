// https://leetcode.com/problems/assign-cookies

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FindContentChildren struct{}

func TestFindContentChildren(t *testing.T) {
	gen := core.TestSuite[FindContentChildren]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3}).Param([]int{1, 1}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2}).Param([]int{1, 2, 3}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{10, 9, 8, 7}).Param([]int{5, 6, 7, 8}).Result(2)
	}).Run(t)
}

func (FindContentChildren) Solution(g []int, s []int) int {
	sort.Ints(g)
	sort.Ints(s)

	cookie := 0
	green := 0
	result := 0
	for green < len(g) && cookie < len(s) {
		if s[cookie] >= g[green] {
			result++
			green++
		}

		cookie++
	}

	return result
}
