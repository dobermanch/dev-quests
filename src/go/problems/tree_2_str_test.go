// https://leetcode.com/problems/construct-string-from-binary-tree

package problems

import (
	"strconv"
	"strings"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type Tree2str struct{}

func TestTree2str(t *testing.T) {
	gen := core.TestSuite[Tree2str]{}
	gen.Run(t)
}

func (Tree2str) Solution(root *TreeNode) string {
	var builder strings.Builder

	var build func(node *TreeNode)
	build = func(node *TreeNode) {
		builder.WriteString(strconv.Itoa(node.Val))

		if node.Left != nil {
			builder.WriteString("(")
			build(node.Left)
			builder.WriteString(")")
		}

		if node.Right != nil {
			if node.Left == nil {
				builder.WriteString("()")
			}

			builder.WriteString("(");
			build(node.Right);
			builder.WriteString(")");
		}
	}

	build(root)

	return builder.String()
}
