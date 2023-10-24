// https://leetcode.com/problems/to-be-or-not-to-be

/**
 * @param {string} val
 * @return {Object}
 */
var expect = function(val) {
    return {
        toBe: function(expected) {
            if (expected === val) {
                return true
            }

            throw "Not Equal"
        },
        notToBe: function(expected) {
            if (expected !== val) {
                return true
            }

            throw "Equal"
        }
    }
};

/**
 * expect(5).toBe(5); // true
 * expect(5).notToBe(5); // throws "Equal"
 */