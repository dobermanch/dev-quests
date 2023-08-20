//https://leetcode.com/problems/path-sum-iii/

namespace LeetCode.Problems;

public sealed class PathSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(PathSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamTree("[5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1]").Param(22).Result(3))
          .Add(it => it.ParamTree("[10, 5, -3, 3, 2, null, 11, 3, -2, null, 1, null, null, null, null, null, null, 6, 3]").Param(8).Result(3))
          .Add(it => it.ParamTree("[10, 5, -3, 3, 2, null, 11, 3, -2, null, 1]").Param(8).Result(3))
          .Add(it => it.ParamTree("[10, 5, -3, 3, 2, null, 11, 3, -2, null, 1, 8]").Param(8).Result(4))
          .Add(it => it.ParamTree("[5, 5, 8, 5, null, 13, 5, 5, 2, null, null, 5, 1]").Param(10).Result(4))
          .Add(it => it.ParamTree("[1, 2]").Param(0).Result(0))
          .Add(it => it.ParamTree("[1, 2]").Param(2).Result(1))
          .Add(it => it.ParamTree("[1, -2, -3, 1, 3, -2, null, -1]").Param(0).Result(2))
          .Add(it => it.ParamTree("[1, -2, -3, 1, 3, -2, null, -1]").Param(1).Result(3))
          .Add(it => it.ParamTree("[1]").Param(1).Result(1))
          .Add(it => it.ParamTree("[0, 1, 1]").Param(1).Result(4))
          .Add(it => it.ParamTree("[-2, null, -3]").Param(-5).Result(1))
          .Add(it => it.ParamTree("[0, 0, null, 0]").Param(0).Result(6))
          .Add(it => it.ParamTree("[1000000000, 1000000000, null, 294967296, null, 1000000000, null, 1000000000, null, 1000000000]").Param(0).Result(0))
          .Add(it => it.ParamTree("[]").Param(1).Result(0));

    private int Solution(TreeNode? root, int targetSum)
    {
        int Search(TreeNode? node, long sum, int target, IDictionary<long, int> map)
        {
            if (node == null)
            {
                return 0;
            }

            var count = 0;

            sum += node.val;
            if (map.ContainsKey(sum - target))
            {
                count += map[sum - target];
            }

            if (map.ContainsKey(sum))
            {
                map[sum]++;
            }
            else
            {
                map.Add(sum, 1);
            }

            count += Search(node.left, sum, target, map);
            count += Search(node.right, sum, target, map);

            map[sum]--;

            return count;
        }

        return Search(root, 0, targetSum, new Dictionary<long, int> { { 0, 1 } });
    }

    private int Solution1(TreeNode? root, int targetSum)
    {
        int Search(TreeNode? node, int level, IList<long> path)
        {
            if (node == null)
            {
                return 0;
            }

            var count = 0;
            if (node.val == targetSum)
            {
                count++;
            }

            long sum = node.val;
            sum += path.LastOrDefault();

            if (sum == targetSum && level > 0)
            {
                count++;
            }

            for (int i = 0; i < path.Count - 1; i++)
            {
                if (sum - path[i] == targetSum)
                {
                    count++;
                }
            }

            path.Add(sum);

            count += Search(node.left, level + 1, path);
            count += Search(node.right, level + 1, path);

            if (path.Any())
            {
                path.RemoveAt(path.Count - 1);
            }

            return count;
        }

        return Search(root, 0, new List<long>());
    }
}