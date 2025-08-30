// https://leetcode.com/problems/alice-and-bob-playing-flower-game

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type AliceAndBobPlayingFlowerGame struct{}

func TestAliceAndBobPlayingFlowerGame(t *testing.T) {
	gen := core.TestSuite[AliceAndBobPlayingFlowerGame]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(100000).Param(100000).Result(5000000000)
	}).Add(func(tc *core.TestCase) {
		tc.Param(10).Param(3).Result(15)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1).Param(1).Result(0)
	}).Run(t)
}

func (AliceAndBobPlayingFlowerGame) Solution(n int, m int) int64 {
	nEven := int64(n / 2)
	nOdd := int64((n + 1) / 2)

	mEven := int64(m / 2)
	mOdd := int64((m + 1) / 2)

	return nEven*mOdd + nOdd*mEven
}
