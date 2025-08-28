// https://leetcode.com/problems/counter-ii/

/**
 * @param {integer} init
 * @return { increment: Function, decrement: Function, reset: Function }
 */
var createCounter2 = function(init) {
    var number = init;
    return {
        increment: function() {
            return ++number
        },
        decrement: function() {
            return --number
        },
        reset: function() {
            return number = init
        }
    }
};

/**
 * const counter = createCounter2(5)
 * counter.increment(); // 6
 * counter.reset(); // 5
 * counter.decrement(); // 4
 */