// https://leetcode.com/problems/word-ladder

package problems

import (
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type WordLadder struct{}

func TestWordLadder(t *testing.T) {
	gen := core.TestSuite[WordLadder]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("hit").Param("cog").Param([]string{"hot", "dot", "dog", "lot", "log", "cog"}).Result(5)
	}).Add(func(tc *core.TestCase) {
		tc.Param("hit").Param("cog").Param([]string{"hot", "dot", "dog", "lot", "log"}).Result(0)
	}).Run(t)
}

func (WordLadder) Solution(beginWord string, endWord string, wordList []string) int {
	wordsSet := make(map[string]struct{}, len(wordList))
	for _, word := range wordList {
		wordsSet[word] = struct{}{}
	}

	type pair struct {
		word  string
		count int
	}
	queue := []pair{{beginWord, 1}}
	seen := map[string]struct{}{beginWord: {}}

	for len(queue) > 0 {
		curr := queue[0]
		queue = queue[1:]

		if curr.word == endWord {
			return curr.count
		}

		for i := 0; i < len(curr.word); i++ {
			for c := 'a'; c <= 'z'; c++ {
				next := curr.word[:i] + string(c) + curr.word[i+1:]
				if _, ok := wordsSet[next]; ok {
					if _, visited := seen[next]; !visited {
						queue = append(queue, pair{next, curr.count + 1})
						seen[next] = struct{}{}
					}
				}
			}
		}
	}

	return 0
}
