// https://leetcode.com/problems/maximum-subsequence-score

package problems

import (
	"math"
	"testing"
	"container/heap"
	"sort"
	"github.com/dobermanch/leetcode/core"
)

type MaxScore struct{}

func TestMaxScore(t *testing.T) {
	gen := core.TestSuite[MaxScore]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1,3,3,2}).Param([]int{2,1,3,4}).Param(3).Result(12)
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{4,2,3,1,1}).Param([]int{7,5,10,9,6}).Param(1).Result(30)
	}).Run(t)
}

func (MaxScore) Solution(nums1 []int, nums2 []int, k int) int64 {
	arr := []Pair{}
    for i := 0; i < len(nums1); i++ {
        arr = append(arr, Pair{item1: nums1[i], item2: nums2[i]})
    }

    sort.Slice(arr, func (i, j int) bool {
        return arr[i].item2 > arr[j].item2
    })

    queue := &MinHeap{}
    sum := 0
	result := 0

    for i := 0; i < len(arr); i++ {
		heap.Push(queue, arr[i].item1)
		sum += arr[i].item1
		k -= 1

		if k <= 0 {
			temp := sum * arr[i].item2
			if result < temp {
				result = temp
			}

			sum -= heap.Pop(queue).(int)
        }
    }

    return int64(result)
}

type Pair struct {
	item1 int
	item2 int
}

type MinHeap []int

func (h MinHeap) Len() int { 
    return len(h) 
}

func (h MinHeap) Less(i, j int) bool { 
    return h[i] < h[j] 
}
func (h MinHeap) Swap(i, j int) {
     h[i], h[j] = h[j], h[i] 
}

func (h *MinHeap) Push(x interface{}) {
    *h = append(*h, x.(int))
}

func (h *MinHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n-1]
    *h = old[0 : n-1]
    return x
}
