#https://leetcode.com/problems/missing-number/
class MissingNumber:
    def Solution(self, nums: list[int]) -> int:
        result = len(nums)

        for i in range(len(nums)):
            result += i - nums[i]

        return result

    def Solution1(self, nums: list[int]) -> int:
        n = len(nums)
        result = n * (n + 1) // 2

        for num in nums:
            result -= num

        return result


MissingNumber().Solution([9,6,4,2,3,5,7,0,1,10,11,12,13])
