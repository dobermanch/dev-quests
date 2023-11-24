// https://leetcode.com/problems/search-suggestions-system

package problems

import (
	"testing"
    "sort"
	"github.com/dobermanch/leetcode/core"
)

type SuggestedProducts struct{}

func TestSuggestedProducts(t *testing.T) {
	gen := core.TestSuite[SuggestedProducts]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]string{"mobile","mouse","moneypot","monitor","mousepad"}).Param("mouse").Result([][]string{{"mobile","moneypot","monitor"},{"mobile","moneypot","monitor"},{"mouse","mousepad"},{"mouse","mousepad"},{"mouse","mousepad"}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]string{"havana"}).Param("havana").Result([][]string{{"havana"},{"havana"},{"havana"},{"havana"},{"havana"},{"havana"}})
	}).Run(t)
}

func (SuggestedProducts) Solution(products []string, searchWord string) [][]string  {
    sort.Strings(products)

    result := [][]string{}
    previous := products
    for i := 0; i < len(searchWord); i++ {
        temp := []string{}
        for _, product := range previous {
            if len(product) > i && product[i] == searchWord[i] {
                temp = append(temp, product)
            }
        }

        previous = temp
        if len(temp) <= 3 {
            result = append(result, temp)
        } else {
            result = append(result, temp[:3])
        }
    }

    return result
}

type Trie struct {
    children [26]*Trie
    words []string
}

func (SuggestedProducts) Solution2(products []string, searchWord string) [][]string  {
    sort.Strings(products)

    root := &Trie{}
    result := [][]string{}

    for _, product := range products {
        current := root
        for _, ch := range product {
            if current.children[ch - 'a'] != nil {
                current = current.children[ch - 'a']
            } else {
                current.children[ch - 'a'] = &Trie{}
                current = current.children[ch - 'a']
            }
            current.words = append(current.words, product)
        }
    }

    node := root
    for _, ch := range searchWord {
        if node != nil && node.children[ch - 'a'] != nil {
            node = node.children[ch - 'a']
            if len(node.words) <= 3 {
                result = append(result, node.words)
            } else {
                result = append(result, node.words[:3])
            }
        } else {
            node = nil
            result = append(result, []string{})
        }        
    }

    return result
}
