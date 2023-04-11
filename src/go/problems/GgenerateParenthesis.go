// https://leetcode.com/problems/generate-parentheses/

package problems

import (
	"testing"
)

func TestGgenerateParenthesis(t *testing.T) {
	result := GgenerateParenthesis(3)
	t.Log(result)
}

func GgenerateParenthesis(n int) []string {
    result := make([]string, 0)

    build(n - 1, n, "(", "", &result)
    return result
}

func build(open int, closed int, parenthesis string, temp string, result *[]string) {
    temp += parenthesis

    if open > 0 {
        build(open - 1, closed, "(", temp, result)
    }

    if closed > open {
        build(open, closed - 1, ")", temp, result)
    }

    if open == 0 && closed == 0 {
        *result = append(*result, temp)
    }

    temp = temp[:len(temp) - 1]
}