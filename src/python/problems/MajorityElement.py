#https://leetcode.com/problems/majority-element/
class MajorityElement:
    def Solution(self, nums: List[int]) -> int:
        result = 0
        count = 0

        for num in nums:
            if count == 0:
                result = num

            count += 1 if result == num else -1
        
        return result


MajorityElement().Solution([1,2,1])
