public class SubarraysDivByK {

    public static void Run(){
        var d = Run(new int[]{4,5,0,-2,-3,1}, 5);
        //var d = Run(new int[]{5}, 9);
    }

    private static int Run(int[] nums, int k) {
        var result = 0;
        var sums = new int[nums.Length];
        sums[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            sums[i] = sums[i - 1] + nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (sums[i] % k == 0)
            {
                result++;
            }

            for (int j = i + 1; j < nums.Length; j++)
            {
                if ((sums[j] - sums[i]) % k == 0)
                {
                    result++;
                }
            }
        }

        return result;
    }
}