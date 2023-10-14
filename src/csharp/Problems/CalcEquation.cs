//https://leetcode.com/problems/evaluate-division

namespace LeetCode.Problems;

public sealed class CalcEquation : ProblemBase
{
    [Theory]
    [ClassData(typeof(CalcEquation))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray<string>("""[["a","b"],["a","c"],["a","d"],["a","e"],["a","f"],["a","g"],["a","h"],["a","i"],["a","j"],["a","k"],["a","l"],["a","aa"],["a","aaa"],["a","aaaa"],["a","aaaaa"],["a","bb"],["a","bbb"],["a","ff"]]""")
                       .ParamArray<double>("[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0,11.0,1.0,1.0,1.0,1.0,1.0,3.0,5.0]")
                       .Param2dArray<string>("""[["d","f"],["e","g"],["e","k"],["h","a"],["aaa","k"],["aaa","i"],["aa","e"],["aaa","aa"],["aaa","ff"],["bbb","bb"],["bb","h"],["bb","i"],["bb","k"],["aaa","k"],["k","l"],["x","k"],["l","ll"]]""")
                       .ResultArray<double>("[1.66667,1.50000,2.50000,0.14286,10.00000,8.00000,4.00000,1.00000,5.00000,0.33333,7.00000,8.00000,10.00000,10.00000,1.10000,-1.00000,-1.00000]"))
          .Add(it => it.Param2dArray<string>("""[["x1","x2"],["x2","x3"],["x3","x4"],["x4","x5"]]""")
                       .ParamArray<double>("[3.0,4.0,5.0,6.0]")
                       .Param2dArray<string>("""[["x1","x5"],["x5","x2"],["x2","x4"],["x2","x2"],["x2","x9"],["x9","x9"]]""")
                       .ResultArray<double>("[360.00000,0.00833,20.00000,1.00000,-1.00000,-1.00000]"))  
          .Add(it => it.Param2dArray<string>("""[["a","b"],["b","c"]]""")
                       .ParamArray<double>("[2.0,3.0]")
                       .Param2dArray<string>("""[["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]""")
                       .ResultArray<double>("[6.00000,0.50000,-1.00000,1.00000,-1.00000]"))
          .Add(it => it.Param2dArray<string>("""[["a","b"],["b","c"],["bc","cd"]]""")
                       .ParamArray<double>("[1.5,2.5,5.0]")
                       .Param2dArray<string>("""[["a","c"],["c","b"],["bc","cd"],["cd","bc"]]""")
                       .ResultArray<double>("[3.75000,0.40000,5.00000,0.20000]"))
          .Add(it => it.Param2dArray<string>("""[["a","b"]]""")
                       .ParamArray<double>("[0.5]")
                       .Param2dArray<string>("""[["a","b"],["b","a"],["a","c"],["x","y"]]""")
                       .ResultArray<double>("[0.50000,2.00000,-1.00000,-1.00000]"));

    private double[] Solution(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) 
    {
        var nodes = new Dictionary<string, List<(string, double)>>();
        for(var i = 0; i < equations.Count; i++)
        {
            (nodes[equations[i][0]] = nodes.GetValueOrDefault(equations[i][0], new ())).Add((equations[i][1], values[i]));
            (nodes[equations[i][1]] = nodes.GetValueOrDefault(equations[i][1], new ())).Add((equations[i][0], 1 / values[i]));
        }

        var result = new double[queries.Count];
        for (var i = 0; i < queries.Count; i++)
        {
            result[i] = Dfs(nodes, queries[i][0], queries[i][1], new HashSet<string>());
        }

        return result;
    }

    private double Dfs(Dictionary<string, List<(string node, double weight)>> nodes, string current, string target, HashSet<string> visited)
    {
        if (!nodes.ContainsKey(current) || !nodes.ContainsKey(target))
        {
            return -1;
        }

        if (current == target)
        {
            return 1;
        }

        visited.Add(current);
        foreach(var (node, weight) in nodes[current])
        {
            if (visited.Contains(node))
            {
                continue;
            }
            
            var result = Dfs(nodes, node, target, visited);
            if (result != -1)
            {
                return result * weight;
            }
        }

        return -1;
    }
}