// https://leetcode.com/problems/to-be-or-not-to-be

type ToBeOrNotToBe = {
    toBe: (val: any) => boolean;
    notToBe: (val: any) => boolean;
};

function expect(val: any): ToBeOrNotToBe {
	return {
        toBe: (expected: any) => {
            if (expected === val) {
                return true;
            }

            throw Error("Not Equal");
        },
        notToBe: (expected: any) => {
            if (expected !== val) {
                return true;
            }

            throw Error("Equal");
        }
    };
};

var result = expect(5).toBe(5); // true
console.log(result)
/**
 * expect(5).toBe(5); // true
 * expect(5).notToBe(5); // throws "Equal"
 */