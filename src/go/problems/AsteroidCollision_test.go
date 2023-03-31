package problems

import "testing"

func TestAsteroidCollision(t *testing.T) {
	result := AsteroidCollision([]int{-2, 1, 1, -1})
	t.Log(result)
}
