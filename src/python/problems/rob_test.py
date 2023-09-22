#https://leetcode.com/problems/house-robber/
class Rob:
    def Solution(self, nums: list[int]) -> int:
        rob1 = 0
        rob2 = 0

        for num in nums:
            temp = max(rob1 + num, rob2)
            rob1 = rob2
            rob2 = temp
        return rob2


Rob().Solution([2,7,4,5,3,5,6,8,5,9,3,1,12])
