package core

import (
	"fmt"
	"testing"
)

type TestInterface struct{}

func Test(t *testing.T) {
	gen := TestSuite[TestInterface]{}
	gen.Add(func(tc *TestCase) {
		tc.Param(1).Param("2").Result("test2")
	}).Add(func(tc *TestCase) {
		tc.Param(3).Param("4").Result("test4")
	}).Run(t)
}

func (TestInterface) Solution(value1 int, value2 string) string {
	fmt.Printf("Solution statement. params[value1: %d, value2: %s]\n", value1, value2)
	return "test" + value2
}

func (TestInterface) Solution1(value1 int, value2 string) string {
	fmt.Printf("Solution 1 statement. params[value1: %d, value2: %s]\n", value1, value2)
	return "test" + value2
}
