//https://leetcode.com/problems/online-stock-span

namespace LeetCode.Problems;

public sealed class StockSpanner : ProblemBase
{
    [Theory]
    [ClassData(typeof(StockSpanner))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Instructions<Scanner, int[]>(config =>
                config
                    .MapConstructor("StockSpanner")
                    .MapInstruction("next", (it, data) => it.Next(data[0]))
           )
           .Add(it => it.Data<int>("""[[],[73],[99],[41],[68],[32],[22],[72],[1],[83],[53]]""")
                        .Instructions("""["StockSpanner","next","next","next","next","next","next","next","next","next","next"]""")
                        .Output("[null,1,2,1,2,1,1,5,1,7,1]"))
           .Add(it => it.Data<int>("""[[], [100], [80], [60], [70], [60], [75], [85]]""")
                        .Instructions("""["StockSpanner", "next", "next", "next", "next", "next", "next", "next"]""")
                        .Output("[null, 1, 1, 1, 2, 1, 4, 6]"));

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