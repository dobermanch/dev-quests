// https://leetcode.com/problems/simplify-path

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type SimplifyPath struct{}

func TestSimplifyPath(t *testing.T) {
	gen := core.TestSuite[SimplifyPath]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("/home//foo/").Result("/home/foo")
	}).Add(func(tc *core.TestCase) {
		tc.Param("/home/").Result("/home")
	}).Add(func(tc *core.TestCase) {
		tc.Param("/../").Result("/")
	}).Run(t)
}

func (SimplifyPath) Solution(path string) string {
	stack := []string{}
	segment := new(strings.Builder)

	for i := 0; i < len(path); i++ {
		if path[i] != '/' {
			segment.WriteByte(path[i])
		}

		if path[i] == '/' || i == len(path)-1 {
			dir := segment.String()
			if dir == ".." && len(stack) > 0 {
				stack = stack[:len(stack)-1]
			} else if len(dir) > 0 && dir != "." && dir != ".." {
				stack = append(stack, dir)
			}

			segment.Reset()
		}
	}

	builder := new(strings.Builder)
	if len(stack) <= 0 {
		builder.WriteByte('/')
	}

	for i := 0; i < len(stack); i++ {
		builder.WriteString("/")
		builder.WriteString(stack[i])
	}

	return builder.String()
}
