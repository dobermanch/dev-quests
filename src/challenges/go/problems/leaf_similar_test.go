// https://leetcode.com/problems/leaf-similar-trees

package problems

import (
	"testing"
)

func TestLeafSimilar(t *testing.T) {
	var node1 = TreeNode{Val: 3, Left: &TreeNode{Val: 5, Left: &TreeNode{Val: 6}, Right: &TreeNode{Val: 2, Left: &TreeNode{Val: 7}, Right: &TreeNode{Val: 4}}}, Right: &TreeNode{Val: 1, Left: &TreeNode{Val: 9}, Right: &TreeNode{Val: 8}}}
	var node2 = TreeNode{Val: 3, Left: &TreeNode{Val: 5, Left: &TreeNode{Val: 6}, Right: &TreeNode{Val: 7}}, Right: &TreeNode{Val: 1, Left: &TreeNode{Val: 4}, Right: &TreeNode{Val: 2, Left: &TreeNode{Val: 9}, Right: &TreeNode{Val: 8}}}}
	
	result := LeafSimilar(&node1, &node2)
	t.Log(result)
}

func LeafSimilar(root1 *TreeNode, root2 *TreeNode) bool {
	var dfs func (node *TreeNode, result *[]int)

	dfs = func (node *TreeNode, result *[]int)  {
		if node != nil && node.Left == nil && node.Right == nil {
			*result = append(*result, node.Val)
			return
		}
	
		if node.Left != nil {
			dfs(node.Left, result)
		}

		if node.Right != nil {
			dfs(node.Right, result)
		}
	}

	result1 := []int{}	
	dfs(root1, &result1)

	result2 := []int{}
	dfs(root2, &result2)

	if len(result1) != len(result2) {
		return false
	}

	for i := 0; i < len(result1); i++ {
		if result1[i] != result2[i] {
			return false
		}
	}

	return true
}