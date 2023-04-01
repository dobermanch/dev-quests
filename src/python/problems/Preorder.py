class Node:
    def __init__(self, val=None, children=None):
        self.val = val
        self.children = children

class Preorder:
    def Solution(self, root: 'Node') -> list[int]:
        result = []
        stack = []
        stack.append(root)
        while len(stack) > 0:
            current = stack.pop()
            result.append(current.val)

            for i in range(len(current.children) - 1, 0, -1):
                stack.append(current.children[i])

        return result


Preorder().Solution(Node(1, [Node(2), Node(3, [Node(6), Node(7, [Node(11)])])]))
