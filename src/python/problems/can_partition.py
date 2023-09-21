#https://leetcode.com/problems/partition-equal-subset-sum/
class CanPartition:
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


CanPartition().Solution([1,5,11,5])
