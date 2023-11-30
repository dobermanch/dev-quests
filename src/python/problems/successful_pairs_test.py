# https://leetcode.com/problems/successful-pairs-of-spells-and-potions

from core.problem_base import *

class SuccessfulPairs(ProblemBase):
    def Solution(self, spells: list[int], potions: list[int], success: int) -> list[int]:
        potions.sort()

        potionsLength = len(potions)
        spellsLength = len(spells)
        result = [0] * spellsLength

        for i in range(spellsLength):
            left = 0
            right = potionsLength - 1
            
            while left <= right:
                mid = (left + right) // 2

                if spells[i] * potions[mid] >= success:
                    right = mid - 1
                else:
                    left = mid + 1
            
            result[i] = potionsLength - left
        
        return result



if __name__ == '__main__':
    TestGen(SuccessfulPairs) \
        .Add(lambda tc: tc.Param("spells", [5,1,3]).Param("potions", [1,2,3,4,5]).Param("success", 7).Result([4,0,3])) \
        .Add(lambda tc: tc.Param("spells", [3,1,2]).Param("potions", [8,5,8]).Param("success", 16).Result([2,0,2])) \
        .Run()
