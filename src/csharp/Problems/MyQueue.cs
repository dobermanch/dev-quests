//https://leetcode.com/problems/implement-queue-using-stacks/

namespace LeetCode.Problems;

public sealed class MyQueue : ProblemBase
{
    [Theory]
    [ClassData(typeof(MyQueue))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases() 
        => Instructions<CustomQueue, int[]>(config =>
                config
                    .MapConstructor("MyQueue")
                    .MapInstruction("push", (it, data) => it.Push(data[0]))
                    .MapInstruction("peek", it => it.Peek())
                    .MapInstruction("pop", it => it.Pop())
                    .MapInstruction("empty", it => it.Empty())
            )
            .Add(tc =>
                  tc.Param2dArray<int>("[[],[1],[2],[],[],[]]", true)
                    .ParamArray<string>("""["MyQueue", "push", "push", "peek", "pop", "empty"]""")
                    .ResultArray<object?>("[null, null, null, 1, 1, false]", true)
            );

    internal class CustomQueue
    {
        private readonly Stack<int> _input = new();
        private readonly Stack<int> _output = new();

        public void Push(int x)
        {
            _input.Push(x);
        }

        public int Pop()
        {
            if (_output.Count > 0)
            {
                return _output.Pop();
            }

            while (_input.Count > 1)
            {
                _output.Push(_input.Pop());
            }

            return _input.Pop();
        }

        public int Peek()
        {
            if (_output.Count > 0)
            {
                return _output.Peek();
            }

            while (_input.Any())
            {
                _output.Push(_input.Pop());
            }

            return _output.Peek();
        }

        public bool Empty()
            => _input.Count == 0 && _output.Count == 0;
    }
}