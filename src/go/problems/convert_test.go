// https://leetcode.com/problems/zigzag-conversion

package problems

import (
	"github.com/dobermanch/leetcode/core"
	"strings"
	"testing"
)

type Convert struct{}

func TestConvert(t *testing.T) {
	gen := core.TestSuite[Convert]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("PAYPALISHIRING").Param(3).Result("PAHNAPLSIIGYIR")
	}).Add(func(tc *core.TestCase) {
		tc.Param("PAYPALISHIRING").Param(4).Result("PINALSIGYAHRPI")
	}).Add(func(tc *core.TestCase) {
		tc.Param("A").Param(1).Result("A")
	}).Add(func(tc *core.TestCase) {
		tc.Param("AR").Param(1).Result("AR")
	}).Run(t)
}

func (Convert) Solution(s string, numRows int) string {
	if numRows == 1 {
		return s
	}

	builders := make([]strings.Builder, numRows)

	count := 0
	direction := 1
	for i := 0; i < len(s); i++ {
		builders[count].WriteByte(s[i])

		if count == 0 {
			direction = 1
		} else if count == numRows-1 {
			direction = -1
		}

		count += direction
	}

	result := strings.Builder{}
	for i := 0; i < numRows; i++ {
		result.WriteString(builders[i].String())
	}

	return result.String()
}
