// https://leetcode.com/problems/minimum-genetic-mutation

package problems

import (
	"container/list"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type MinimumGeneticMutation struct{}

func TestMinimumGeneticMutation(t *testing.T) {
	gen := core.TestSuite[MinimumGeneticMutation]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("AACCGGTT").Param("AACCGCTA").Param([]string{"AACCGGTA", "AACCGCTA", "AAACGGTA"}).Result(2)
	}).Run(t)
}

func (MinimumGeneticMutation) Solution(startGene string, endGene string, bank []string) int {
	bankSet := make(map[string]bool)
	for _, gene := range bank {
		bankSet[gene] = true
	}

	seen := make(map[string]int)
	queue := list.New()
	queue.PushBack(struct {
		gene  string
		index int
		count int
	}{endGene, len(endGene) - 1, 0})

	for queue.Len() > 0 {
		elem := queue.Front()
		queue.Remove(elem)
		current := elem.Value.(struct {
			gene  string
			index int
			count int
		})

		gene := current.gene
		index := current.index
		count := current.count

		if gene == startGene {
			return count
		}

		if !bankSet[gene] {
			continue
		}

		if _, exists := seen[gene]; exists {
			index--
		} else {
			count++
			index = len(endGene) - 1
			seen[gene] = count
		}

		if index < 0 {
			continue
		}

		for _, l := range []rune{'A', 'C', 'G', 'T'} {
			mutated := gene[:index] + string(l) + gene[index+1:]
			queue.PushBack(struct {
				gene  string
				index int
				count int
			}{mutated, index, seen[gene]})
		}
	}

	return -1
}
