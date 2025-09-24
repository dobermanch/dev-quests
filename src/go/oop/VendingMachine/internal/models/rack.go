package models

type Rack struct {
	Number  string
	Product Product
	Count   int
}

func (r *Rack) IsEmpty() bool {
	return r.Count <= 0
}
