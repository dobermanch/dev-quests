// https://leetcode.com/problems/unique-number-of-occurrences/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type UniqueOccurrences struct{}

func TestUniqueOccurrences(t *testing.T) {
	gen := core.TestSuite[UniqueOccurrences]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2,2,1,1,3}).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1,2}).Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{-3,0,1,-3,1,1,1,-3,10,0}).Result(true)
	}).Run(t)
}

func (UniqueOccurrences) Solution(arr []int) bool {
	occ := map[int]int{}
	for _,v := range arr {
		occ[v]++
	}

	unique := map[int]struct{}{}
	for _,v := range occ {
		unique[v] = struct{}{}
	}

	return len(occ) == len(unique)
}
