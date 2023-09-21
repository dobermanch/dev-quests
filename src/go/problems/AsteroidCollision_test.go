// https://leetcode.com/problems/asteroid-collision/

package problems

import "testing"

func TestAsteroidCollision(t *testing.T) {
	result := AsteroidCollision([]int{-2, 1, 1, -1})
	t.Log(result)
}

func AsteroidCollision(asteroids []int) []int {
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
