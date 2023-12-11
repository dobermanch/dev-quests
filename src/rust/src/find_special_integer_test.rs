// https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array

pub fn solution(arr: Vec<i32>) -> i32 {
	let minCount = arr.len() / 4;
	for i in 0..arr.len() - minCount {
		if arr[i] == arr[i + minCount] {
			return arr[i]
		}
	}

	arr[0]
}

pub fn solution2(arr: Vec<i32>) -> i32 {
    let minCount = arr.len() / 4;
    let mut count = 1;
    for i in 1..arr.len() {
        count = if arr[i - 1] == arr[i] { count + 1 } else { 1 };
        if count > minCount {
            return arr[i]
        }
    }

    arr[0]
}
