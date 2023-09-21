package core

import (
	"bytes"
	"fmt"
	"reflect"
	"strings"
	"testing"
)

type TestSuite[T any] struct {
	testCases      []TestCase
	solutions      []string
	class          T
	solutionPrefix string
}

func (tg *TestSuite[T]) Add(configure func(testCase *TestCase)) *TestSuite[T] {
	testCase := TestCase{}
	configure(&testCase)
	tg.testCases = append(tg.testCases, testCase)
	return tg
}

func (tg *TestSuite[T]) Run(t *testing.T) {
	tp := reflect.TypeOf(*tg)
	field, ok := tp.FieldByName("class")
	if ok {
		tg.class = reflect.New(field.Type).Elem().Interface().(T)
		tg.solutions = tg.findSolutions()
		tg.testCases = tg.getTestCases()

		tg.runTests(t)
	} else {
		t.Errorf("Cannot run test, because the TestGen.class field is not found")
	}
}

func (tg TestSuite[T]) runTests(t *testing.T) {
	for i := 0; i < len(tg.testCases); i++ {
		testCase := tg.testCases[i]
		method := reflect.ValueOf(tg.class).MethodByName(testCase.name)

		var buffer bytes.Buffer
		buffer.WriteString(testCase.name)
		buffer.WriteString("(")
		values := []reflect.Value{}
		for i := 0; i < len(testCase.params); i++ {
			values = append(values, reflect.ValueOf(testCase.params[i]))
			if i != 0 {
				buffer.WriteString(", ")
			}
			buffer.WriteString(fmt.Sprintf("%v", testCase.params[i]))
		}
		buffer.WriteString(") => ")
		buffer.WriteString(fmt.Sprintf("%v", testCase.result))

		t.Log(buffer.String())

		result := method.Call(values)
		if len(result) == 0 {
			t.Errorf("Test did not return any result, make sure that solution methods return value")
			return
		}

		resultValue := result[0].Interface()
		if resultValue != testCase.result {
			t.Errorf("%s. Output %v not equal to expected %v", buffer.String(), resultValue, testCase.result)
		}
	}
}

func (tg TestSuite[T]) findSolutions() []string {
	instanceType := reflect.TypeOf(tg.class)

	solutions := []string{}
	for i := 0; i < instanceType.NumMethod(); i++ {
		method := instanceType.Method(i)
		if tg.solutionPrefix == "" || strings.HasPrefix(method.Name, tg.solutionPrefix) {
			solutions = append(solutions, method.Name)
		}
	}

	return solutions
}

func (tg TestSuite[T]) getTestCases() []TestCase {
	testCases := []TestCase{}
	for i := 0; i < len(tg.testCases); i++ {
		testCase := tg.testCases[i].Clone()
		for j := 0; j < len(tg.solutions); j++ {
			testCase.name = tg.solutions[j]
			testCases = append(testCases, testCase)
		}
	}

	return testCases
}
