# https://leetcode.com/problems/clone-graph/
from models.node import *
from core.problem_base import *

class CloneGraph(ProblemBase):
    def Solution(self, node: 'Node') -> 'Node':
        def Clone(source, map):
            if source.val in map:
                return map[source.val]

            clone = Node(source.val)

            map[source.val] = clone

            for neighbor in source.neighbors:
                clone.neighbors.append(Clone(neighbor, map))

            return clone

        return Clone(node, {}) if node else None

if __name__ == '__main__':
    node1 = Node(1)
    node2 = Node(2)
    node3 = Node(3)
    node4 = Node(4)

    node1.neighbors.append(node2)
    node1.neighbors.append(node4)
    node2.neighbors.append(node1)
    node2.neighbors.append(node3)
    node3.neighbors.append(node2)
    node3.neighbors.append(node4)
    node4.neighbors.append(node1)
    node4.neighbors.append(node3)

    TestGen(CloneGraph) \
        .Add(lambda tc: tc.Param(node1).Result(node1)) \
        .Run()
