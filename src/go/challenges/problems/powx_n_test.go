// https://leetcode.com/problems/powx-n/

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type MyPow struct{}

func TestMyPow(t *testing.T) {
	gen := core.TestSuite[MyPow]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param(2.0).Param(10).Result(1024.0)
	}).Add(func(tc *core.TestCase) {
		tc.Param(2.1).Param(3).Result(9.26100)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(2.0).Param(0).Result(1.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(0.0).Param(21).Result(0.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(2.0).Param(-2147483648).Result(0.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(1.0).Param(-2147483648).Result(1.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(-1.0).Param(-2147483648).Result(1.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(-1.0).Param(2147483647).Result(-1.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(1.0).Param(2147483647).Result(1.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(1.0000000000001).Param(-2147483648).Result(0.99979)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(-5.0).Param(-12).Result(0.0)
	}).Add(func(tc *core.TestCase) { 
		tc.Param(2.0).Param(-2).Result(0.25)
	}).Run(t);
}

func (MyPow) Solution(x float64, n int) float64  {
	if x == 0 {
		return 0
	}

	pow := n
	num := x
	if pow < 0 {
		pow = -pow
		num = 1.0 / num
	}

	var result float64 = 1
	for pow != 0 {
		if pow % 2 != 0 {
			result *= num
		}

		num *= num
		pow /= 2
	}

	return result
}
