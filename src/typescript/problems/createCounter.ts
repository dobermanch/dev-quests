// https://leetcode.com/problems/counter

function createCounter(n: number): () => number {
    var number = n
    return function() {
		return number++
    }
}


/** 
 * const counter = createCounter(10)
 * counter() // 10
 * counter() // 11
 * counter() // 12
 */