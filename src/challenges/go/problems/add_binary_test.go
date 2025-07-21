// https://leetcode.com/problems/add-binary

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type AddBinary struct{}

func TestAddBinary(t *testing.T) {
	gen := core.TestSuite[AddBinary]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("11").Param("1").Result("100")
	}).Add(func(tc *core.TestCase) {
		tc.Param("1010").Param("1011").Result("10101")
	}).Add(func(tc *core.TestCase) {
		tc.Param("1101010").Param("111").Result("1110001")
	}).Run(t)
}

func (AddBinary) Solution(a string, b string) string {
	if len(a) > len(b) {
		b = strings.Repeat("0", len(a)-len(b)) + b
	} else {
		a = strings.Repeat("0", len(b)-len(a)) + a
	}

	result := make([]byte, len(a))
	carry := byte(0)
	for i := len(a) - 1; i >= 0; i-- {
		temp := a[i] - '0' + b[i] - '0' + carry
		bit := byte(temp % 2)
		carry = byte(temp / 2)
		result[i] = bit + '0'
	}

	if carry == 1 {
		result = append([]byte{'1'}, result...)
	}

	return string(result)
}
