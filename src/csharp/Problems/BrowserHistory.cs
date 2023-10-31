//https://leetcode.com/problems/design-browser-history/

namespace LeetCode.Problems;

public sealed class BrowserHistory : ProblemBase
{
    [Theory]
    [ClassData(typeof(BrowserHistory))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param2dArray<object>("""[["esgriv.com"],["cgrt.com"],["tip.com"],[9],["kttzxgh.com"],[7],["crqje.com"],["iybch.com"],[5],["uun.com"],[10],["hci.com"],["whula.com"],[10]]""", true)
                       .ParamArray<string>("""["BrowserHistory","visit","visit","back","visit","forward","visit","visit","forward","visit","back","visit","visit","forward"]""")
                       .ResultArray<object?>(null, null, null, "esgriv.com", null, "kttzxgh.com", null, null, "iybch.com", null, "esgriv.com", null, null, "whula.com"))
          .Add(it => it.Param2dArray<object>("""[["leetcode.com"],["google.com"],["facebook.com"],["youtube.com"],[1],[1],[1],["linkedin.com"],[2],[2],[7]]""", true)
                       .ParamArray<string>("""["BrowserHistory","visit","visit","visit","back","back","forward","visit","forward","back","back"]""")
                       .ResultArray<object?>(null, null, null, null, "facebook.com", "google.com", "facebook.com", null, "linkedin.com", "google.com", "leetcode.com"));

    private IList<object?> Solution(object[][] data, string[] instructions)
    {
        var result = new List<object?>();

        var browser = new CustomBrowserHistory(data[0][0] as string);
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "BrowserHistory":
                    result.Add(null);
                    break;
                case "visit":
                    result.Add(null);
                    browser.Visit((string)data[i][0]);
                    break;
                case "back":
                    result.Add(browser.Back((int)data[i][0]));
                    break;
                case "forward":
                    result.Add(browser.Forward((int)data[i][0]));
                    break;
            }
        }

        return result;
    }

    public class CustomBrowserHistory
    {
        private readonly LinkedList<string> _history = new();
        private LinkedListNode<string>? _current;

        public CustomBrowserHistory(string? homepage)
        {
            if (homepage != null)
            {
                _current = _history.AddFirst(homepage);
            }
        }

        public void Visit(string url)
        {
            if (_current == null)
            {
                _current = _history.AddLast(url);
            }
            else
            {
                _current = _history.AddAfter(_current, url);

                var node = _current?.Next;
                while (node != null)
                {
                    var temp = node.Next;
                    _history.Remove(node);
                    node = temp;
                }
            }
        }

        public string? Back(int steps)
        {
            var node = _current;
            while (node != null && steps-- > 0)
            {
                node = node.Previous;
            }

            _current = node ?? _history.First;

            return _current?.Value;
        }

        public string? Forward(int steps)
        {
            var node = _current;
            while (node != null && steps-- > 0)
            {
                node = node.Next;
            }

            _current = node ?? _history.Last;

            return _current?.Value;
        }
    }
}