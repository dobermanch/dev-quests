// https://leetcode.com/problems/h-index

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type HIndex struct{}

func TestHIndex(t *testing.T) {
	gen := core.TestSuite[HIndex]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 0, 6, 1, 5}).Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 3, 1}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{100}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3, 1, 7, 8, 9}).Result(3)
	}).Run(t)
}

func (HIndex) Solution(citations []int) int {
	length := len(citations)

	sort.Ints(citations)

	for i := 0; i < length; i++ {
		if citations[i] < length-i {
			continue
		}

		for hIndex := citations[i]; hIndex >= 0; hIndex-- {
			if hIndex <= length-i {
				return hIndex
			}
		}
	}

	return 0
}
