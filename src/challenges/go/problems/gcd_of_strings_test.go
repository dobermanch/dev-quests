// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type GcdOfStrings struct{}

func TestGcdOfStrings(t *testing.T) {
	gen := core.TestSuite[GcdOfStrings]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("ABCABC").Param("ABC").Result("ABC")
	}).Add(func(tc *core.TestCase) {
		tc.Param("ABABAB").Param("ABAB").Result("AB")
	}).Add(func(tc *core.TestCase) {
		tc.Param("TAUXXTAUXXTAUXXTAUXXTAUXX").Param("TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX").Result("TAUXX")
	}).Add(func(tc *core.TestCase) {
		tc.Param("ABCABD").Param("ABC").Result("")
	}).Add(func(tc *core.TestCase) {
		tc.Param("LEET").Param("CODE").Result("")
	}).Run(t)
}

func (GcdOfStrings) Solution1(str1 string, str2 string) string {
	if !(str1+str2 == str2+str1) {
		return ""
	}

	return str1[:gcd(len(str1), len(str2))]
}

func gcd(left, right int) int {
	if right == 0 {
		return left
	}

	return gcd(right, left%right)
}

func (GcdOfStrings) Solution2(str1 string, str2 string) string {
	result := str2

	for len(result) > 0 {
		if strings.Replace(str1, result, "", -1) == "" && strings.Replace(str2, result, "", -1) == "" {
			return result
		}

		result = result[:len(result)-1]
	}

	return ""
}
