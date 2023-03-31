//https://leetcode.com/problems/implement-trie-prefix-tree/

namespace LeetCode.Problems;

public sealed class Trie : ProblemBase
{
    [Theory]
    [ClassData(typeof(Trie))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray<string>(@"[[], [""apple""], [""apple""], [""app""], [""app""], [""app""], [""app""]]", true)
            .ParamArray("Trie", "insert", "search", "search", "startsWith", "insert", "search")
            .ResultArray<object?>(null, null, true, false, true, null, true))
          .Add(it => it.Param2dArray<string>(@"[[],[""ab""],[""a""],[""a""]]", true)
            .ParamArray("Trie", "insert", "search", "startsWith")
            .ResultArray<object?>(null, null, false, true));

    private IList<object?> Solution(string[][] data, string[] instructions)
    {
        var result = new List<object?>();

        var trie = new CustomTrie();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case "Trie":
                    result.Add(null);
                    break;
                case "insert":
                    result.Add(null);
                    trie.Insert(data[i][0]);
                    break;
                case "search":
                    result.Add(trie.Search(data[i][0]));
                    break;
                case "startsWith":
                    result.Add(trie.StartsWith(data[i][0]));
                    break;
            }
        }

        return result;
    }

    public class CustomTrie
    {
        class Node
        {
            public bool IsWord { get; set; }

            public Node?[] Children { get; } = new Node?[26];
        };

        private readonly Node _root = new();

        public void Insert(string word)
        {
            var node = _root;

            foreach (var ch in word)
            {
                node = node.Children[ch - 'a'] ??= new Node();
            }

            node.IsWord = true;
        }

        public bool Search(string word)
        {
            var node = FindNode(word);

            return node?.IsWord == true;
        }

        public bool StartsWith(string prefix)
        {
            return  FindNode(prefix) != null;
        }

        private Node? FindNode(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                if (node!.Children[ch - 'a'] is null)
                {
                    return null;
                }

                node = node.Children[ch - 'a'];
            }

            return node;
        }
    }
}