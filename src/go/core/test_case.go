package core

type TestCase struct {
	name     string
	params   []interface{}
	result   interface{}
	disabled bool
}

func (tc *TestCase) Param(param interface{}) *TestCase {
	tc.params = append(tc.params, param)
	return tc
}

func (tc *TestCase) Result(result interface{}) *TestCase {
	tc.result = result
	return tc
}

func (tc *TestCase) Disable(disabled bool) *TestCase {
	tc.disabled = disabled
	return tc
}

func (tc *TestCase) Clone() TestCase {
	cloned := *tc
	cloned.params = make([]interface{}, len(tc.params))
	copy(cloned.params, tc.params)
	return cloned
}
