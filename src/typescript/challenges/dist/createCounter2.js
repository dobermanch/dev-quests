"use strict";
// https://leetcode.com/problems/counter-ii
function createCounter2(init) {
    var number = init;
    return {
        increment: () => {
            return ++number;
        },
        decrement: () => {
            return --number;
        },
        reset: () => {
            return number = init;
        }
    };
}
;
/**
 * const counter = createCounter2(5)
 * counter.increment(); // 6
 * counter.reset(); // 5
 * counter.decrement(); // 4
 */ 
//# sourceMappingURL=createCounter2.js.map