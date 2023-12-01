from core.test_case import TestCase

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

    def __repr__(self) -> str:
        return str(self)

    def __str__(self) -> str:
        sb = ""
        queue = []
        queue.append(self)
        while queue:
            node = queue.pop(0)
            sb += f",{node.val}"
            if node.left:
                queue.append(node.left)

            if node.right:
                queue.append(node.right)

        sb = sb[1:]
        sb = "[" + sb + "]"

        return sb
    
    def __hash__(self) -> int:
        prime = 31
        result = 1
        result = prime * result + hash(self.val)
        result = prime * result + hash(self.left)
        result = prime * result + hash(self.right)
        return result

    def __eq__(self, __value: object) -> bool:
        if not self and not __value:
            return True
        
        if (not self and __value) or (self and not __value):
            return False
        
        if self is __value:
            return True
        
        if self.val != __value.val:
            return False
        
        if self.left != __value.left:
            return False
        
        return self.right == __value.right

    def Create(param: any):
        if not param:
            return None

        root = TreeNode(param[0])
        queue = []
        queue.append(root)
        index = 0
        while queue and index < len(param):
            node = queue.pop(0)
            index += 1
            if index < len(param) and param[index] is not None:
                node.left = TreeNode(param[index])
                queue.append(node.left)

            index += 1
            if index < len(param) and param[index] is not None:
                node.right = TreeNode(param[index])
                queue.append(node.right)

        return root

def TestCaseExtension(cls):
    def decorator(func):
        setattr(cls, func.__name__, func)
        return func
    return decorator
    
@TestCaseExtension(TestCase)
def ParamTreeNode(self, param: any):
    return self.Param(TreeNode.Create(param))

@TestCaseExtension(TestCase)
def ResultTreeNode(self, param: any):
    return self.Result(TreeNode.Create(param))