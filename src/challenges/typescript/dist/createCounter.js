"use strict";
// https://leetcode.com/problems/counter
function createCounter(n) {
    return function () {
        return n++;
    };
}
/**
 * const counter = createCounter(10)
 * counter() // 10
 * counter() // 11
 * counter() // 12
 */ 
//# sourceMappingURL=createCounter.js.map