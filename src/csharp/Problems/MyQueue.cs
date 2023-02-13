//https://leetcode.com/problems/implement-queue-using-stacks/

namespace LeetCode.Problems;

public sealed class MyQueue : ProblemBase
{
    [Theory]
    [ClassData(typeof(MyQueue))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray("[[],[1],[2],[],[],[]]", true).ParamArray("MyQueue", "push", "push", "peek", "pop", "empty").ResultArray<object>(null, null, null, 1, 1, false));

    private IList<object> Solution(int[][] data, string[] instructions)
    {
        var result = new List<object>();

        var queue = new CustomQueue();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "MyQueue":
                    result.Add(null);
                    break;
                case "push":
                    result.Add(null);
                    queue.Push(data[i][0]);
                    break;
                case "peek":
                    result.Add(queue.Peek());
                    break;
                case "pop":
                    result.Add(queue.Pop());
                    break;
                case "empty":
                    result.Add(queue.Empty());
                    break;
            }
        }

        return result;
    }

    public class CustomQueue
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