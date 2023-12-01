from typing import Optional
from core.test_case import TestCase

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
        self.IsCycleNode = False

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

            node1 = node1.next if node1.next and not node1.next.IsCycleNode else None
            node2 = node2.next if node2.next and not node2.next.IsCycleNode else None

        return True

    def Create(param: any, cycleAtPos: Optional[int] = None):
        if not param:
            return None

        root = ListNode(param[0])
        cycleTo = None
        if cycleAtPos == 0:
            cycleTo = root

        current = root
        for i in range(1, len(param)):
            current.next = ListNode(param[i])
            current = current.next

            if i == cycleAtPos:
                cycleTo = current

        if cycleTo:
            cycleTo.IsCycleNode = True
            current.next = cycleTo

        return root

def TestCaseExtension(cls):
    def decorator(func):
        setattr(cls, func.__name__, func)
        return func
    return decorator
    
@TestCaseExtension(TestCase)
def ParamListNode(self, param: any):
    return self.Param(ListNode.Create(param))

@TestCaseExtension(TestCase)
def ResultListNode(self, param: any):
    return self.Result(ListNode.Create(param))