// https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/

package problems

import (
	"testing"
)

type LongestZigZag struct {}

func TestLongestZigZag(t *testing.T) {
	var node1 = TreeNode{Val: 1, Right: &TreeNode{Val: 1, Left: &TreeNode{Val: 1}, Right: &TreeNode{Val: 1, Left: &TreeNode{Val: 1, Right: &TreeNode{Val: 1, Right: &TreeNode{Val: 1}}}, Right: &TreeNode{Val: 1}}}}
	
	result := LongestZigZag{}.Solution(&node1)
	t.Log(result)
}

func (LongestZigZag) Solution(root *TreeNode) int {
    var dfs func (node *TreeNode, depth int, goLeft bool) int

    dfs = func(node *TreeNode, depth int, goLeft bool) int {
        if node == nil {
            return depth - 1
        }

        current := 0
        alternative := 0
        if goLeft {
            current = dfs(node.Left, depth + 1, !goLeft)
            alternative = dfs(node.Right, 1, goLeft)
        } else {
            current = dfs(node.Right, depth + 1, !goLeft);
            alternative = dfs(node.Left, 1, goLeft);
        }

        if current > alternative {
            return current
        } else {
            return alternative
        }
    }

    return dfs(root, 0, true)
}