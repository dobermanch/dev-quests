//https://leetcode.com/problems/text-justification

namespace LeetCode.Problems;

public sealed class FullJustify : ProblemBase
{
    [Theory]
    [ClassData(typeof(FullJustify))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it
                .ParamArray<string>("""["ask","not","what","your","country","can","do","for","you","ask","what","you","can","do","for","your","country"]""")
                .Param(16)
                .ResultArray<string>("""["ask   not   what","your country can","do  for  you ask","what  you can do","for your country"]"""))
          .Add(it => it
                .ParamArray<string>("""["The","important","thing","is","not","to","stop","questioning.","Curiosity","has","its","own","reason","for","existing."]""")
                .Param(17)
                .ResultArray<string>("""["The     important","thing  is  not to","stop questioning.","Curiosity has its","own   reason  for","existing.        "]"""))
          .Add(it => it
                .ParamArray<string>("""["This", "is", "an", "example", "of", "text", "justification."]""")
                .Param(16)
                .ResultArray<string>("""["This    is    an", "example  of text", "justification.  "]"""))
          .Add(it => it
                .ParamArray<string>("""["What","must","be","acknowledgment","shall","be"]""")
                .Param(16)
                .ResultArray<string>("""["What   must   be", "acknowledgment  ", "shall be        "]"""))
          .Add(it => it
                .ParamArray<string>("""["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"]""")
                .Param(20)
                .ResultArray<string>("""["Science  is  what we","understand      well","enough to explain to","a  computer.  Art is","everything  else  we","do                  "]"""));

    private IList<string> Solution(string[] words, int maxWidth)
    {
        var result = new List<string>();

        var length = -1;
        var left = 0;
        var right = 0;
        while (right < words.Length)
        {
            length += words[right].Length + 1;

            if (right + 1 < words.Length && length + 1 + words[right + 1].Length <= maxWidth)
            {
                right++;
                continue;
            }

            var intervals = right - left;
            var remain = 0;
            var spaces = 1;
            if (right < words.Length - 1 && intervals > 0)
            {
                spaces = maxWidth - (length - intervals);
                remain = spaces % intervals;
                spaces = spaces / intervals;
            }

            var builder = new StringBuilder(words[left]);
            for (var i = left + 1; i <= left + intervals; i++)
            {
                builder.Append(' ', spaces + (remain-- > 0 ? 1 : 0));
                builder.Append(words[i]);
            }

            builder.Append(' ', maxWidth - builder.Length);

            result.Add(builder.ToString());
            left = ++right;
            length = -1;
        }

        return result;
    }
}
