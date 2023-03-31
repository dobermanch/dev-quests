//https://leetcode.com/problems/word-search-ii/

namespace LeetCode.Problems;

public sealed class WordSearch2 : ProblemBase
{
    [Theory]
    [ClassData(typeof(WordSearch2))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param2dArray<char>("""[['o','a','a','n'],['e','t','a','e'],['i','h','k','r'],['i','f','l','v']]""")
                       .ParamArray<string>("""["oath","pea","eat","rain"]""")
                       .ResultArray<string>("""["oath","eat"]"""))
          .Add(it => it.Param2dArray<char>("""[['a','b'],['c','d']]""")
                       .ParamArray<string>("""["abcb"]""")
                       .ResultArray<string>("[]"))
          .Add(it => it.Param2dArray<char>("""[['o','a','b','n'],['o','t','a','e'],['a','h','k','r'],['a','f','l','v']]""")
                       .ParamArray<string>("""["oa","oaa"]""")
                       .ResultArray<string>("""["oa","oaa"]"""))
          .Add(it => it.Param2dArray<char>("""[['o','a','a','n'],['e','t','a','e'],['i','h','k','r'],['i','f','l','v']]""")
                       .ParamArray<string>("""["oath","pea","eat","rain","oathi","oathk","oathf","oate","oathii","oathfi","oathfii"]""")
                       .ResultArray<string>("""["oate","oath","oathk","oathi","oathii","oathf","oathfi","oathfii","eat"]"""));

    private IList<string> Solution(char[][] board, string[] words)
    {
        var trie = new TrieNode();
        foreach (var word in words)
        {
            trie.Insert(word);
        }

        var result = new List<string>(words.Length);
        for (var y = 0; y < board.Length; y++)
        {
            for (var x = 0; x < board[0].Length; x++)
            {
                if (trie.GetNode(board[y][x]) != null)
                {
                    Search(board, x, y, trie, result);
                }
            }
        }

        return result;
    }

    private void Search(char[][] board, int x, int y, TrieNode trie, IList<string> result)
    {
        if (x < 0 || x >= board[0].Length
         || y < 0 || y >= board.Length
         || board[y][x] < 'A')
        {
            return;
        }

        var node = trie.GetNode(board[y][x]);
        if (node == null)
        {
            return;
        }

        if (node.Word is not null)
        {
            result.Add(node.Word);
            node.Remove();
        }

        board[y][x] -= 'A';

        Search(board, x + 1, y, node, result);
        Search(board, x - 1, y, node, result);
        Search(board, x, y + 1, node, result);
        Search(board, x, y - 1, node, result);

        board[y][x] += 'A';
    }

    class TrieNode
    {
        public string? Word { get; private set; }

        private TrieNode?[] Children { get; } = new TrieNode?[26];

        public void Insert(string word)
        {
            var node = this;
            foreach (var ch in word)
            {
                node = node.Children[ch - 'a'] ??= new TrieNode();
            }

            node.Word = word;
        }

        public void Remove() => Word = null;

        public TrieNode? GetNode(char ch) => Children[ch - 'a'];
    }
}