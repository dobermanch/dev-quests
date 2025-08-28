// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

import (
	"math"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type NumTilings struct{}

func TestNumTilings(t *testing.T) {
	gen := core.TestSuite[NumTilings]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(1000).Result(979232805)
	}).Add(func(tc *core.TestCase) {
		tc.Param(7).Result(117)
	}).Add(func(tc *core.TestCase) {
		tc.Param(6).Result(53)
	}).Add(func(tc *core.TestCase) {
		tc.Param(4).Result(11)
	}).Add(func(tc *core.TestCase) {
		tc.Param(3).Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param(2).Result(2)
	}).Add(func(tc *core.TestCase) {
		tc.Param(1).Result(1)
	}).Run(t)
}

func (NumTilings) Solution(n int) int {
	if n == 1 {
		return 1
	}

	mod := int(math.Pow(10, 9)) + 7
	treeBack := 0
	twoBack := 1
	oneBack := 1
	result := 0
	for i := 0; i < n - 1; i++ {
		result = (oneBack * 2 + treeBack) % mod
		treeBack = twoBack
		twoBack = oneBack
		oneBack = result
	}

	return int(result)
}
