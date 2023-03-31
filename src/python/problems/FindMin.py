class FindMin:
    def Solution(self, nums: List[int]) -> int:
        left = 0
        right = len(nums) - 1
        
        while left < right:
            mid = (left + right) // 2
            if nums[right] < nums[mid]:
                left = mid + 1
            else:
                right = mid

        return nums[left]


FindMin().Solution([4,5,6,7,0,1,2])
