# https://leetcode.com/problems/copy-list-with-random-pointer

from typing import Optional
from core.problem_base import *
from models.node import Node

class CopyRandomList:
    def Solution(self, head: Optional[Node]) -> Optional[Node]:
        set = {None: None}

        node = head
        while node:
            set[node] = Node(node.val)
            node = node.next
        
        root = Node(0)
        current = root
        node = head
        while node:
            current.next = set[node]
            current.next.next = set[node.next]
            current.next.random = set[node.random]

            node = node.next
            current = current.next

        return root.next


    def Solution1(self, head: 'Optional[Node]') -> 'Optional[Node]':
        def Clone(source, map):
            if not source:
                return None
            
            if source in map:
                return map[source]

            clone = Node(source.val)

            map[source] = clone

            clone.next = Clone(source.next, map)
            clone.random = Clone(source.random, map)

            return clone

        return Clone(head, {})

if __name__ == '__main__':
    node0 = Node(7)
    node1 = Node(13)
    node2 = Node(11)
    node3 = Node(10)
    node4 = Node(1)

    node0.next = node1
    node0.random = None
    node1.next = node2
    node1.random = node0
    node2.next = node3
    node2.random = node4
    node3.next = node4
    node3.random = node2
    node4.next = None
    node4.random = node0

    TestGen(CopyRandomList) \
        .Add(lambda tc: tc.Param("head", node0).Result(node0)) \
        .Run()
