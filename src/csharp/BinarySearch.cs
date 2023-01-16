public class BinarySearch {

    public static void Run(){
        //var d = Run(new int[]{-1,0,3,5,9,12}, 9);
        var d = Run(new int[]{-1,0,3,5,9,12}, 2);
    }

    private static int Run(int[] nums, int target) {
        var start = 0;
        var end = nums.Length - 1;
        do
        {
            var mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target) 
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        while (end >= start);

        return -1;
    }
}