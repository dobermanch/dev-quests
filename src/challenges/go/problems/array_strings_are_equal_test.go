// https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type ArrayStringsAreEqual struct{}

func TestArrayStringsAreEqual(t *testing.T) {
	gen := core.TestSuite[ArrayStringsAreEqual]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"ab", "c"}).Param([]string{"a", "bc"}).Result(true)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"a", "cb"}).Param([]string{"ab", "c"}).Result(false)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"abc", "d", "defg"}).Param([]string{"abcddefg"}).Result(true)
	}).Run(t)
}

func (ArrayStringsAreEqual) Solution1(word1 []string, word2 []string) bool {
    return strings.Join(word1, "") == strings.Join(word2, "")
}

func (ArrayStringsAreEqual) Solution2(word1 []string, word2 []string) bool {
    build := func(words []string) string {
        var builder strings.Builder
        for _, word := range words {
            builder.WriteString(word);
        }

        return builder.String();
    }

    return build(word1) == build(word2);
}