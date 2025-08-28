#https://leetcode.com/problems/search-suggestions-system

from core.problem_base import *

class SuggestedProducts(ProblemBase):
    def Solution1(self, products: list[str], searchWord: str) -> list[list[str]]:
        products.sort()

        result = []
        previous = products
        for i in range(len(searchWord)):
            temp = []
            for product in previous:
                if len(product) > i and product[i] == searchWord[i]:
                    temp.append(product)

            previous = temp
            if len(temp) <= 3:
                result.append(temp)
            else:
                result.append(temp[:3])

        return result
    
    def Solution2(self, products: list[str], searchWord: str) -> list[list[str]]:
        root = Trie()

        products.sort()
        for product in products:
            current = root
            for ch in product:
                if ch in current.children:
                    current = current.children[ch] 
                else:
                    current.children[ch] = Trie()
                    current = current.children[ch]
                current.words.append(product)
        
        result = []
        node = root
        for ch in searchWord:
            node = node.children[ch] if node and ch in node.children else None
            result.append(node.words[:3] if node else [])

        return result
    
class Trie:
    def __init__(self) -> None:
        self.children = {}
        self.words = []

if __name__ == '__main__':
    TestGen(SuggestedProducts) \
        .Add(lambda tc: tc.Param(["mobile","mouse","moneypot","monitor","mousepad"]).Param("mouse").Result([["mobile","moneypot","monitor"],["mobile","moneypot","monitor"],["mouse","mousepad"],["mouse","mousepad"],["mouse","mousepad"]])) \
        .Add(lambda tc: tc.Param(["havana"]).Param("havana").Result([["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]])) \
        .Run()
