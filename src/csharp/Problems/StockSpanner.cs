//https://leetcode.com/problems/online-stock-span

namespace LeetCode.Problems;

public sealed class StockSpanner : ProblemBase
{
    [Theory]
    [ClassData(typeof(StockSpanner))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<int>("""[[],[73],[99],[41],[68],[32],[22],[72],[1],[83],[53]]""", true)
                       .ParamArray<string>("""["StockSpanner","next","next","next","next","next","next","next","next","next","next"]""")
                       .ResultArray<object?>("[null,1,2,1,2,1,1,5,1,7,1]", true))
          .Add(it => it.Param2dArray<int>("""[[], [100], [80], [60], [70], [60], [75], [85]]""", true)
                       .ParamArray<string>("""["StockSpanner", "next", "next", "next", "next", "next", "next", "next"]""")
                       .ResultArray<object?>("[null, 1, 1, 1, 2, 1, 4, 6]", true));

    private IList<object?> Solution(int[][] data, string[] instructions)
    {
        var result = new List<object?>();

        var obj = new Scanner();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "StockSpanner":
                    result.Add(null);
                    break;
                case "next":
                    result.Add(obj.Next(data[i][0]));
                    break;
            }
        }

        return result;
    }

    public class Scanner
    {
        private readonly Stack<(int span, int val)> _stack = new();

        public int Next(int price) 
        {
            var span = 1;
            while (_stack.Count > 0 && _stack.Peek().val <= price)
            {
                span += _stack.Pop().span;
            }

            _stack.Push((span, price));
            
            return span;
        }
    }
}