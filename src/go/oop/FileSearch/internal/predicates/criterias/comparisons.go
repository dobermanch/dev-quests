package criterias

import "strings"

type Number interface {
	int | int8 | int16 | int32 | int64 |
		uint | uint8 | uint16 | uint32 | uint64 |
		float32 | float64
}

type CompareNumbers[T Number] func(T, T) bool

type CompareStrings func(string, string) bool

func Equals[T Number](source T, target T) bool {
	return source == target
}

func GreaterThan[T Number](source T, target T) bool {
	return source > target
}

func GreaterThanOrEquals[T Number](source T, target T) bool {
	return source >= target
}

func LessThan[T Number](source T, target T) bool {
	return source < target
}

func LessThanOrEquals[T Number](source T, target T) bool {
	return source <= target
}

func CaseInsensitive(source string, target string) bool {
	return strings.EqualFold(source, target)
}

func CaseSensitive(source string, target string) bool {
	return strings.EqualFold(source, target)
}
