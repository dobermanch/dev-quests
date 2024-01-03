// https://leetcode.com/problems/number-of-laser-beams-in-a-bank

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type NumberOfBeams struct{}

func TestNumberOfBeams(t *testing.T) {
	gen := core.TestSuite[NumberOfBeams]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"011001", "000000", "010100", "001000"}).Result(8)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"000", "111", "000"}).Result(0)
	}).Run(t)
}

func (NumberOfBeams) Solution(bank []string) int {
	result := 0
	prevDevices := 0
	for i := 0; i < len(bank); i++ {
		devices := 0
		for j := 0; j < len(bank[i]); j++ {
			if bank[i][j] == '1' {
				devices++
			}
		}

		if devices > 0 {
			result += devices * prevDevices
			prevDevices = devices
		}
	}

	return result
}
