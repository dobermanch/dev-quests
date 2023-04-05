#https://leetcode.com/problems/maximum-product-subarray
class MaxProduct:
    def Solution(self, nums: List[int]) -> int:
        result = nums[0]
        maxProd = 1
        minProd = 1
        for num in nums:
            prod1 = num * maxProd
            prod2 = num * minProd

            maxProd = max(num, prod1, prod2)
            minProd = min(num, prod1, prod2)

            result = max(result, maxProd)

        return result


MaxProduct().Solution([1,1,1])
