#https://leetcode.com/problems/maximum-average-subarray-i/

import sys
from core.problem_base import *

class FindMaxAverage(ProblemBase):
    def Solution(self, nums: list[int], k: int) -> float:

        result = -sys.maxsize - 1  
        window = 0
        for i in range(len(nums)):            
            window += nums[i]

            left = i - k + 1
            avg = window / k
            if left >= 0 and result < avg:
                result = avg
            
            if left >= 0:
                window -= nums[left]
        
        return result

if __name__ == '__main__':
    TestGen(FindMaxAverage) \
        .Add(lambda tc: tc.Param([5]).Param(1).Result(5.00000)) \
        .Add(lambda tc: tc.Param([1,12,-5,-6,50,3]).Param(4).Result(12.75000)) \
        .Add(lambda tc: tc.Param([-1]).Param(1).Result(-1.00000)) \
        .Add(lambda tc: tc.Param([-6662,5432,-8558,-8935,8731,-3083,4115,9931,-4006,-3284,-3024,1714,-2825,-2374,-2750,-959,6516,9356,8040,-2169,-9490,-3068,6299,7823,-9767,5751,-7897,6680,-1293,-3486,-6785,6337,-9158,-4183,6240,-2846,-2588,-5458,-9576,-1501,-908,-5477,7596,-8863,-4088,7922,8231,-4928,7636,-3994,-243,-1327,8425,-3468,-4218,-364,4257,5690,1035,6217,8880,4127,-6299,-1831,2854,-4498,-6983,-677,2216,-1938,3348,4099,3591,9076,942,4571,-4200,7271,-6920,-1886,662,7844,3658,-6562,-2106,-296,-3280,8909,-8352,-9413,3513,1352,-8825]).Param(90).Result(37.25556)) \
        .Run()
