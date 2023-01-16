//https://leetcode.com/problems/non-decreasing-subsequences/description/
using System.Collections;
public class FindSubsequences {

    public static void Run(){
        var d = Run(new int[] {4,6,7,7});
        //var d = Run(new int[] {4,4,3,2,1});
    }

    private static IList<IList<int>> Run(int[] nums) 
    {
        var result = new List<IList<int>>();

        Find(nums, 0, new List<int>(), result);

        return result;
    }

    private static void Find(int[] nums, int index, List<int> res, List<IList<int>> result)
    {
        if (res.Count > 1)
        {
            result.Add(res.ToArray());
        }

        if (index == nums.Length)
        {
            return;
        }

        var visited = new HashSet<int>();
        for (var next = index; next < nums.Length; next++) 
        {
            if (visited.Contains(nums[next]) || res.Any() && res.Last() > nums[next])
            {
                continue;
            }

            res.Add(nums[next]);
            Find(nums, next + 1, res, result);
            res.Remove(res.Last());
            visited.Add(nums[next]);
        }
    }

    // private static IList<IList<int>> Run(int[] nums)  {
    //     var result = new HashSet<MyList>();

    //     Find(nums, 0, new List<int>(), result);

    //     return result.ToArray();
    // }

    // private static void Find(int[] nums, int index, List<int> res, HashSet<MyList> result)
    // {
    //     if (index == nums.Length)
    //     {
    //         if (res.Count > 1)
    //         {
    //             result.Add(new MyList(res));
    //         }

    //         return;
    //     }

    //     if (!res.Any() || res.Last() <= nums[index])
    //     {
    //         res.Add(nums[index]);
    //         Find(nums, index + 1, res, result);
    //         res.Remove(res.Last());
    //     }

    //     Find(nums, index + 1, res, result);
    // }

    // class MyList: List<int> {
    //     public MyList(IList<int> data) : base (data) { }
    //     public override bool Equals(object? obj) => obj?.GetHashCode() == GetHashCode();
    //     public override int GetHashCode() => this.Aggregate(0, (hash, next) => HashCode.Combine(hash, next));
    // }
}