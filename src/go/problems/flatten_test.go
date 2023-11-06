// https://leetcode.com/problems/flatten-binary-tree-to-linked-list

package problems

import (
	"testing"
	"github.com/dobermanch/leetcode/core"
)

type Flatten struct{}

func TestFlatten(t *testing.T) {
	gen := core.TestSuite[Flatten]{}
	gen.Add(func(tc *core.TestCase) {
		root := TreeNode{
			Val: 1,
			Left: &TreeNode{ 
				Val: 2,
				Left: &TreeNode{ Val: 3 },
				Right: &TreeNode{ Val: 4 }
			},
			Right: &TreeNode{ 
				Val: 5,
				Right: &TreeNode{ Val: 6 }
			}
		}

		tc.Param(&root).Result(&root)
	}).Run(t)
}

func (Flatten) Solution1(root *TreeNode) *TreeNode {
	node := root
    for (node != nil) {
        if (node.Left != nil) {
            current := node.Left
            for (current.Right != nil) {
                current = current.Right                
            }

            current.Right = node.Right
            node.Right = node.Left
            node.Left = nil
        }

        node = node.Right
    }

	return root
}

func (Flatten) Solution2(root *TreeNode) *TreeNode {
	stack := []*TreeNode{}

	node := root
	var prev *TreeNode
	for (node != nil || len(stack) > 0) {
		if (node != nil) {
			stack = append(stack, node)
			prev = node
			node = node.Left
		} else {
			pop := stack[len(stack) - 1]
			stack = stack[:len(stack) - 1]
			node = pop.Right

			if (prev != nil) {
				prev.Right = node
				if (pop.Left != nil) {
					pop.Right = pop.Left
					pop.Left = nil
				}
			}
		}
	}

	return root
}
