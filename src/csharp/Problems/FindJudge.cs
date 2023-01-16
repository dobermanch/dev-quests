//https://leetcode.com/problems/find-the-town-judge/description/
public class FindJudge {

    public static void Run(){
        //var d = Run(3, new int[][] { new [] { 1, 3 }, new [] { 2, 3 }});
        //var d = Run(2, new int[][] { new [] { 1, 2 }});
        var d = Run(3, new int[][] { new [] { 1, 3 }, new [] { 2, 3 }, new [] { 3, 1 }});
    }

    private static int Run(int n, int[][] trust)
    {
        var map = new int[n, 2];

        for (var i = 0; i < trust.Length; i++)
        {
            map[trust[i][1] - 1, 0] += 1;
            map[trust[i][0] - 1, 1] = 1;
        }

        for (var i = 0; i < n; i++)
        {
            if (map[i, 0] == n - 1 && map[i, 1] == 0)
            {
                return i + 1;
            }
        }

        return -1;
    }
}