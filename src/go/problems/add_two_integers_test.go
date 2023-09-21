// https://leetcode.com/problems/running-sum-of-1d-array/

package problems

import "testing"

func TestAddTwoIntegers(t *testing.T) {
	result := AddTwoIntegers(10, 12)
	t.Log(result)


}

func AddTwoIntegers(num1 int, num2 int) int {
	return num1 + num2
}