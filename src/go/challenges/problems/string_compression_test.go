// https://leetcode.com/problems/string-compression

package problems

import (
	"strconv"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Compress struct{}

func TestCompress(t *testing.T) {
	gen := core.TestSuite[Compress]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([] byte{'a','a','b','b','c','c','c'}).Result(6)
	}).Add(func(tc *core.TestCase) {
		tc.Param([] byte{'a'}).Result(1)
	}).Add(func(tc *core.TestCase) {
		tc.Param([] byte{'a','b','b','b','b','b','b','b','b','b','b','b','b'}).Result(4)
	}).Run(t)
}

func (Compress) Solution(chars []byte) int {

	compress := func(data []byte, index int, current byte, count int) int {
		data[index] = current
		index++
		if count > 1 {
			digits := []byte(strconv.Itoa(count))
			for j := 0; j < len(digits); j++ {
				chars[index] = digits[j]
				index++
			}
		}

		return index
	}

	left := 0
	right := 1
	current := chars[0]
	count := 1
	for right < len(chars) {
		if chars[right] == current {
			count++
			right++
			continue
		}

		left = compress(chars, left, current, count)

		current = chars[right]
		count = 1
		right++
	}

	return compress(chars, left, current, count)
}
