from core.test_case import TestCase


class Node:
    def __init__(self, val = 0, neighbors = None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []
        self.children = []
        self.next = None
        self.random = None

    def __init__(self, x: int, next: 'Node' = None, random: 'Node' = None):
        self.val = int(x)
        self.next = next
        self.random = random
        self.neighbors = []
        self.children = []

    def __repr__(self) -> str:
        return str(self)

    def __str__(self) -> str:
        sb = f"[{self.val}"
        node = self.next
        while node:
            sb += f",{node.val}"
            if node.IsCycleNode:
                sb += "*"

            node = node.next if node.next and not node.next.IsCycleNode else None
        
        sb += "]"

        return sb
    
    def __hash__(self) -> int:
        prime = 31
        result = 1
        result = prime * result + hash(self.val)
        result = prime * result + hash(self.next)
        return result
    
    def __eq__(self, __value: object) -> bool:
        if not self and not __value:
            return True
        
        if self is __value:
            return True
        
        node1 = self
        node2 = __value
        while node1 or node2:
            if node1.val != node2.val:
                return False

            if node1.random != node2.random:
                return False
                        
            for i, neighbor in enumerate(node1.neighbors):
                if len(node2.neighbors) < i or neighbor.val != node2.neighbors[i].val:
                    return False

            node1 = node1.next
            node2 = node2.next

        return True

    def Create(param: any, link: bool = False):
        if not param:
            return None

        root = Node(param[0])
        queue = []
        queue.append((root, 0))
        index = 0
        while queue:
            node, level = queue.pop()

            if link and queue[-1].level == level:
                node.next = queue[-1].node

            index += 1
            if index < len(param) and param[index]:
                node.left = Node(param[index])
                queue.append((node.left, level + 1))

            index += 1
            if index < len(param) and param[index]:
                node.right = Node(param[index])
                queue.append((node.right, level + 1))

        return root


def TestCaseExtension(cls):
    def decorator(func):
        setattr(cls, func.__name__, func)
        return func
    return decorator
    
@TestCaseExtension(TestCase)
def ParamNode(self, param: any):
    return self.Param(Node.Create(param))

@TestCaseExtension(TestCase)
def ResultNode(self, param: any):
    return self.Result(Node.Create(param))