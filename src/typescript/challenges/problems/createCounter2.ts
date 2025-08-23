// https://leetcode.com/problems/counter-ii

type ReturnObj = {
    increment: () => number,
    decrement: () => number,
    reset: () => number,
}

function createCounter2(init: number): ReturnObj {
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
    }
};

/**
 * const counter = createCounter2(5)
 * counter.increment(); // 6
 * counter.reset(); // 5
 * counter.decrement(); // 4
 */