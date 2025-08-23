"use strict";
// https://leetcode.com/problems/to-be-or-not-to-be
function expect(val) {
    return {
        toBe: (expected) => {
            if (expected === val) {
                return true;
            }
            throw Error("Not Equal");
        },
        notToBe: (expected) => {
            if (expected !== val) {
                return true;
            }
            throw Error("Equal");
        }
    };
}
;
var result = expect(5).toBe(5); // true
console.log(result);
/**
 * expect(5).toBe(5); // true
 * expect(5).notToBe(5); // throws "Equal"
 */ 
//# sourceMappingURL=toBeOrNotToBe.js.map