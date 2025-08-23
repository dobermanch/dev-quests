// https://leetcode.com/problems/top-k-frequent-elements/
package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type TopKFrequentElement struct{}

func TestTopKFrequentElement(t *testing.T) {
	gen := core.TestSuite[TopKFrequentElement]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,1,1,2,2,3}).Param(2).Result([]int{1,2})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1}).Param(1).Result([]int{1})
	}).Run(t)
}

func (TopKFrequentElement)Solution(nums []int, k int) []int {
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
