// https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type NearestExit struct{}

func TestNearestExit(t *testing.T) {
	gen := core.TestSuite[NearestExit]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([][]byte{{'+', '+', '.', '+'}, {'.', '.', '.', '+'}, {'+', '+', '+', '.'}}).Param([]int{1, 2}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]byte{{'+', '+', '+'}, {'.', '.', '.'}, {'+', '+', '+'}}).Param([]int{1, 0}).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param([][]byte{{'.', '+'}}).Param([]int{0, 0}).Result(-1)
	}).Run(t)
}

type Tuple struct {
	count int
	x     int
	y     int
}

func (NearestExit) Solution(maze [][]byte, entrance []int) int {
	direction := [][]int{{1, 0}, {-1, 0}, {0, 1}, {0, -1}}
	rows := len(maze)
	cols := len(maze[0])

	queue := []Tuple{}

	queue = append(queue, Tuple{0, entrance[1], entrance[0]})
	for len(queue) > 0 {
		tuple := queue[0]
		queue = queue[1:]

		if (tuple.x == 0 || tuple.x == cols-1 || tuple.y == 0 || tuple.y == rows-1) && (tuple.x != entrance[1] || tuple.y != entrance[0]) {
			return tuple.count
		}

		for i := range direction {
			var x1 = tuple.x + direction[i][0]
			var y1 = tuple.y + direction[i][1]
			if x1 >= 0 && x1 < cols && y1 >= 0 && y1 < rows && maze[y1][x1] != '+' {
				queue = append(queue, Tuple{tuple.count + 1, x1, y1})
				maze[y1][x1] = '+'
			}
		}
	}

	return -1
}
