// https://leetcode.com/problems/edit-distance

package problems

import (
	"sort"
	"testing"
	"math"
	"github.com/dobermanch/leetcode/core"
)

type MinDistance struct{}

func TestMinDistance(t *testing.T) {
	gen := core.TestSuite[MinDistance]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("horse").Param("ros").Result(3)
	}).Add(func(tc *core.TestCase) {
		tc.Param("intention").Param("execution").Result(5)
	}).Run(t)
}

func (MinDistance) Solution(word1 string, word2 string) int {
    minFunc := func(left int, right int) int {
        if left < right {
            return left
        }
        return right
    }

    height := len(word1)
    width := len(word2)

    result := make([][]int, height + 1)

    for i := 0; i <= height; i++ {
        result[i] = make([]int, width + 1)
        result[i][0] = i
    }

    for i := 0; i <= width; i++ {
        result[0][i] = i;
    }

    for i := 1; i <= height; i++ {
        for j := 1; j <= width; j++ {
            add := 0
            if word1[i - 1] != word2[j - 1] {
                add = 1
            }
            
            min := minFunc(result[i - 1][j] + 1, result[i][j - 1] + 1)
            result[i][j] = minFunc(min, result[i - 1][j - 1] + add)
        }
    }

    return result[height][width]
}
