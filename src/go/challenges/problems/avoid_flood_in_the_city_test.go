// https://leetcode.com/problems/avoid-flood-in-the-city

package problems

import (
	"sort"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type AvoidFloodInTheCity struct{}

func TestAvoidFloodInTheCity(t *testing.T) {
	gen := core.TestSuite[AvoidFloodInTheCity]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 3, 4}).Result([]int{-1, -1, -1, -1})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 0, 0, 2, 1}).Result([]int{-1, -1, 2, 1, -1, -1})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 2, 0, 1, 2}).Result([]int{})
	}).Run(t)
}

func (AvoidFloodInTheCity) Solution(rains []int) []int {
	result := make([]int, len(rains))
	rivers := map[int]int{}
	dryDays := []int{}

	for i, rain := range rains {
		if rain <= 0 {
			dryDays = append(dryDays, i)
			result[i] = 1
			continue
		}

		result[i] = -1

		if day, ok := rivers[rain]; ok {
			index := sort.SearchInts(dryDays, day)
			if index == len(dryDays) {
				return []int{}
			}

			result[dryDays[index]] = rain
			copy(dryDays[index:len(dryDays)-1], dryDays[index+1:])
			dryDays = dryDays[:len(dryDays)-1]
		}

		rivers[rain] = i
	}

	return result
}
