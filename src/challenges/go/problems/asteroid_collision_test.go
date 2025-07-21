// https://leetcode.com/problems/asteroid-collision/

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type AsteroidCollision struct{}

func TestAsteroidCollision(t *testing.T) {
	gen := core.TestSuite[AsteroidCollision]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{5, 10, -5}).Result([]int{5, 10})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{8, -8}).Result([]int{})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{10, 2, -5}).Result([]int{10})
	}).Run(t)
}

func (AsteroidCollision) Solution(asteroids []int) []int {
	stack := make([]int, 0, len(asteroids))
	for _, asteroid := range asteroids {
		add := true

		for len(stack) > 0 && stack[len(stack)-1] > 0 && asteroid < 0 {
			if stack[len(stack)-1] < -asteroid {
				stack = stack[:len(stack)-1]
				continue
			}

			add = false
			if stack[len(stack)-1] == -asteroid {
				stack = stack[:len(stack)-1]
			}

			break
		}

		if add {
			stack = append(stack, asteroid)
		}
	}

	return stack
}
