#https://leetcode.com/problems/partition-equal-subset-sum/
from core.problem_base import *

class CanPartition(ProblemBase):
    def Solution(self, nums: list[int]) -> bool:
        targetSum = sum(nums)

        if targetSum % 2 != 0:
            return False

        targetSum = targetSum // 2

        map = [False] * (targetSum + 1)
        map[0] = True

        for num in nums:
            for i in range(targetSum, num - 1, -1):
                map[i] = map[i] or map[i - num]

            if map[targetSum]:
                return True

        return map[targetSum]


if __name__ == '__main__':
    TestGen(CanPartition) \
        .Add(lambda tc: tc.Param([1,5,11,5]).Result(True)) \
        .Add(lambda tc: tc.Param([1,2,3,5]).Result(False)) \
        .Run()
