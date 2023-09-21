#https://leetcode.com/problems/increasing-triplet-subsequence
class IncreasingTriplet:
    def Solution(self, nums: list[int]) -> bool:
        n1 = sys.maxsize
        n2 = sys.maxsize

        for num in nums:
            if num > n2:
                return True
            
            if num <= n1:
                n1 = num
            elif num < n2:
                n2 = num

        return False


IncreasingTriplet().Solution([1,1,1], 2)
