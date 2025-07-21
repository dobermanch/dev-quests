//https://leetcode.com/problems/implement-trie-prefix-tree/

namespace LeetCode.Problems;

public sealed class Trie : ProblemBase
{
    [Theory]
    [ClassData(typeof(Trie))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Instructions<CustomTrie, string[]>(config =>
                config
                    .MapConstructor("Trie")
                    .MapInstruction("insert", (it, data) => it.Insert(data[0]))
                    .MapInstruction("search", (it, data) => it.Search(data[0]))
                    .MapInstruction("startsWith", (it, data) => it.StartsWith(data[0]))
           )
           .Add(it => it.Data<string>(@"[[], [""apple""], [""apple""], [""app""], [""app""], [""app""], [""app""]]")
                        .Instructions("""["Trie", "insert", "search", "search", "startsWith", "insert", "search"]""")
                        .Output("[null, null, true, false, true, null, true]"))
           .Add(it => it.Data<string>(@"[[],[""ab""],[""a""],[""a""]]")
                        .Instructions("""["Trie", "insert", "search", "startsWith"]""")
                        .Output("[null, null, false, true]"));

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