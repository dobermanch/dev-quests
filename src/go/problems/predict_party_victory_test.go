// https://leetcode.com/problems/dota2-senate

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type PredictPartyVictory struct{}

func TestPredictPartyVictory(t *testing.T) {
	gen := core.TestSuite[PredictPartyVictory]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param("RD").Result("Radiant")
	}).Add(func(tc *core.TestCase) {
		tc.Param("RDD").Result("Dire")
	}).Add(func(tc *core.TestCase) {
		tc.Param("RRDDD").Result("Radiant")
	}).Add(func(tc *core.TestCase) {
		tc.Param("DRRDRDRDRDDRDRDR").Result("Radiant")
	}).Run(t)
}

func (PredictPartyVictory) Solution(senate string) string {
	voting := []rune{};
	radiantTotal := 0
    radiantSkip := 0
	direTotal := 0
    direSkip := 0

	for _,senator := range senate {
		if senator == 'R' {
			radiantTotal++
		} else {
			direTotal++
		}

		voting = append(voting, senator)
	}

	for radiantTotal > 0 && direTotal > 0 {
		if voting[0] == 'R' {
			if radiantSkip <= 0 {
				direSkip++
				direTotal--
				voting = append(voting, voting[0])
			} else {
				radiantSkip--
			}
		} else if direSkip <= 0 {
			radiantSkip++
			radiantTotal--
			voting = append(voting, voting[0])
		} else {
			direSkip--
		}   

		voting = voting[1:]
	}

	if direTotal == 0 {
		return "Radiant"
	} else { 
		return "Dire"
	}
}

func (PredictPartyVictory) Solution1(senate string) string {
	radiant := []int{}
    dire := []int{}

    for order, senator := range senate {
        if senator == 'R' {
            radiant = append(radiant, order)
        } else {
            dire = append(dire, order)
        }
    }

    for len(radiant) > 0 && len(dire) > 0 {
        if radiant[0] < dire[0] {
            radiant = append(radiant, radiant[0] + len(senate))
        } else {
            dire = append(dire, dire[0] + len(senate))
        }

        radiant = radiant[1:]
        dire = dire[1:]
    }

    if len(radiant) > 0 {
        return "Radiant"
    } else {
        return "Dire"
    }
}
