// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/

package problems

import (
	"testing"
)

type MaxLevelSum struct {}

func TestMaxLevelSum(t *testing.T) {
	var node1 = TreeNode{
        Val: 1, 
        Left: &TreeNode{Val: 7, Left: &TreeNode{Val: 7}, Right: &TreeNode{Val: -8}}, 
        Right: &TreeNode{Val: 0}}
	
	result := MaxLevelSum{}.Solution(&node1)
	t.Log(result)
}

func (MaxLevelSum) Solution(root *TreeNode) int {
    queue := []*TreeNode{root}

    result := 1
    maxSum := root.Val
    level := 1
    for len(queue) > 0 {
        sum := 0
        length := len(queue)

        for i:= 0; i < length; i++ {
            node := queue[0]
            queue = queue[1:]

            sum += node.Val

            if node.Left != nil {
                queue = append(queue, node.Left)
            }

            if node.Right != nil {
                queue = append(queue, node.Right)
            }
        }

        if sum > maxSum {
            maxSum = sum
            result = level
        }

        level++
    }

    return result
}