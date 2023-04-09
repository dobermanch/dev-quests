#https://leetcode.com/problems/longest-increasing-subsequence/
class LengthOfLIS:
    def Solution(self, nums: list[int]) -> int:
        map = [0] * len(nums)
        for i in range(len(nums) - 1, -1, -1):
            for j in range(i + 1, len(nums)):
                if nums[i] < nums[j]:
                    map[i] = max(map[i], map[j])
            map[i] += 1

        return max(map)
    
    def Solution1(self, nums: list[int]) -> int:
        sub = [nums[0]]
        for i in range(1, len(nums)):
            if nums[i] > sub[-1]:
                sub.append(nums[i])
                continue

            for j in range(len(sub)):
                if nums[i] <= sub[j]:
                    sub[j] = nums[i]
                    break

        return len(sub)


LengthOfLIS().Solution1([4,10,4,3,8,9])
