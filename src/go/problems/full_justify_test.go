// https://leetcode.com/problems/text-justification

package problems

import (
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FullJustify struct{}

func TestFullJustify(t *testing.T) {
	gen := core.TestSuite[FullJustify]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"This", "is", "an", "example", "of", "text", "justification."}).Param(16).Result([]string{"This    is    an", "example  of text", "justification.  "})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"What", "must", "be", "acknowledgment", "shall", "be"}).Param(16).Result([]string{"What   must   be", "acknowledgment  ", "shall be        "})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"}).Param(20).Result([]string{"Science  is  what we", "understand      well", "enough to explain to", "a  computer.  Art is", "everything  else  we", "do                  "})
	}).Run(t)
}

func (FullJustify) Solution(words []string, maxWidth int) []string {
	result := []string{}

	length := -1
	left := 0
	right := 0
	wordsCount := len(words)
	for right < wordsCount {
		length += len(words[right]) + 1

		if right+1 < wordsCount && length+1+len(words[right+1]) <= maxWidth {
			right++
			continue
		}

		intervals := right - left
		remain := 0
		spaces := 1
		if right < wordsCount-1 && intervals > 0 {
			spaces = maxWidth - (length - intervals)
			remain = spaces % intervals
			spaces = spaces / intervals
		}

		var builder strings.Builder
		builder.WriteString(words[left])
		for i := left + 1; i <= left+intervals; i++ {
			if remain > 0 {
				builder.WriteString(strings.Repeat(" ", spaces+1))
			} else {
				builder.WriteString(strings.Repeat(" ", spaces))
			}
			builder.WriteString(words[i])
			remain--
		}

		builder.WriteString(strings.Repeat(" ", maxWidth-builder.Len()))

		result = append(result, builder.String())
		right++
		left = right
		length = -1
	}

	return result
}
