// https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type FindMinArrowShots struct{}

func TestFindMinArrowShots(t *testing.T) {
	gen := core.TestSuite[FindMinArrowShots]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]int{{10,16},{2,8},{1,6},{7,12}}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1,2},{3,4},{5,6},{7,8}}).Result(4)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]int{{1,2},{2,3},{3,4},{4,5}}).Result(2)
	}).Run(t)
}

func (FindMinArrowShots) Solution(points [][]int) int {
	sort.Slice(points, func(i, j int) bool {
        return points[i][1] < points[j][1]
    })

    result := 1
    end := points[0][1]
    for _, point := range points {
        if end < point[0] {
            end = point[1]
            result++
        }
    }

    return result
}
