#https://leetcode.com/problems/house-robber-ii/
class Rob2:
    def Solution(self, nums: list[int]) -> int:
        if len(nums) == 1:
            return nums[0]

        def RobHouses(start, end):
            rob1 = 0
            rob2 = 0

            for i in range(start, end):
                temp = max(rob1 + nums[i], rob2)
                rob1 = rob2
                rob2 = temp
            return rob2

        return max(RobHouses(0, len(nums) - 1), RobHouses(1, len(nums)))


Rob2().Solution([2,7,4,5,3,5,6,8,5,9,3,1,12])
