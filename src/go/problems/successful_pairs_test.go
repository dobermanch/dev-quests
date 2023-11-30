// https://leetcode.com/problems/successful-pairs-of-spells-and-potions

package problems

import (
	"testing"
    "sort"
	"github.com/dobermanch/leetcode/core"
)

type SuccessfulPairs struct{}

func TestSuccessfulPairs(t *testing.T) {
	gen := core.TestSuite[SuccessfulPairs]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{5,1,3}).Param([]int{1,2,3,4,5}).Param(7).Result([]int{4,0,3})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{3,1,2}).Param([]int{8,5,8}).Param(16).Result([]int{2,0,2})
	}).Run(t)
}

func (SuccessfulPairs) Solution(spells []int, potions []int, success int64) []int {
    sort.Ints(potions)

    potionsLength := len(potions)
    spellsLength := len(spells)
    result := make([]int, spellsLength)
    
    for i := 0; i < spellsLength; i++ {
        left := 0
        right := potionsLength - 1
        spell := int64(spells[i])
        for left <= right {
            mid := (left + right) / 2

            if spell * int64(potions[mid]) >= success {
                right = mid - 1
            } else {
                left = mid + 1
            }
        }

        result[i] = potionsLength - left
    }

    return result
}
