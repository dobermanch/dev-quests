#https://leetcode.com/problems/jump-game/
class CanJump:
    def Solution(self, nums: list[int]) -> bool:
        jumpTo = len(nums) - 1
        for i in range(len(nums) - 1, -1, -1):
            if i + nums[i] >= jumpTo:
                jumpTo = i

        return jumpTo == 0



CanJump().Solution([2,3,1,1,4])
