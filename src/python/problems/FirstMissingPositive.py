#https://leetcode.com/problems/first-missing-positive/
class FirstMissingPositive:
    def Solution(self, nums: list[int]) -> int:
        length = len(nums)
        for i in range(length):
            while nums[i] > 0 and nums[i] <= length and nums[i] != nums[nums[i] - 1]:
                nums[nums[i] - 1], nums[i] = nums[i], nums[nums[i] - 1]
        
        for i in range(length):
            if nums[i] != i + 1:
                return i + 1

        return length + 1


FirstMissingPositive().Solution([1,2,0])
