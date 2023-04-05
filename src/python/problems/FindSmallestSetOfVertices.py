#https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes/
class SubarraySum:
    def FindSmallestSetOfVertices(self, n: int, edges: List[List[int]]) -> List[int]:
        result = set(range(n))

        for edge in edges:
            if edge[1] in result:
                result.remove(edge[1])
        
        return result


FindSmallestSetOfVertices().Solution(5, [[1,3],[2,0],[2,3],[1,0],[4,1],[0,3]])
