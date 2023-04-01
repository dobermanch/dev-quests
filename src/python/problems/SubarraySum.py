#https://leetcode.com/problems/subarray-sum-equals-k/
class SubarraySum:
    def Solution(self, nums: List[int], k: int) -> int:
        map = {}
        map[0] = 1
        result = 0
        sum = 0
        for i, num in enumerate(nums):
            sum += num

            if sum - k in map:
                result += map[sum - k]

            map[sum] = map.get(sum, 0) + 1

        return result


SubarraySum().Solution([1,1,1], 2)
