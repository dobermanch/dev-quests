//https://leetcode.com/problems/decode-string/

namespace LeetCode.Problems;

public sealed class DecodeString : ProblemBase
{
    public static void Run()
    {
        //var d = Run("3[a]2[bc]"); // aaabcbc
        //var d = Run("3[a2[c]]3[f]"); // accaccacc
        var d = Run("3[a10[bc]]"); // abcbcbcbcbcbcbcbcbcbcabcbcbcbcbcbcbcbcbcbcabcbcbcbcbcbcbcbcbcbc
        //var d = Run("3[z]2[2[y]pq4[2[jk]e1[f]]]ef"); //zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef
    }

    private static string Run(string s)
    {
        var numberStack = new Stack<int>();
        var textStack = new Stack<string>();
        int number = 0;
        var text = new StringBuilder();
        foreach (var c in s)
        {
            if (char.IsDigit(c))
            {
                number *= 10;
                number += c - '0';
                if (number <= 9)
                {
                    textStack.Push(text.ToString());
                    text.Clear();
                }
            }
            else if (c == '[')
            {
                numberStack.Push(number);
                number = 0;
            }
            else if (char.IsLetter(c))
            {
                text.Append(c);
            }
            else if (c == ']')
            {
                var repeat = numberStack.Pop();
                var temp = text;
                for (var i = 1; i < repeat; i++)
                {
                    text.Append(temp);
                }

                if (textStack.Any())
                {
                    text.Insert(0, textStack.Pop());
                }
            }
        }

        return text.ToString();
    }

    //Option 1
    private static string Run1(string s)
    {
        var stack = new Stack<string>();
        string number = null;
        string text = null;
        foreach (var c in s)
        {
            if (char.IsDigit(c))
            {
                number += c;
                if (number.Length == 1)
                {
                    stack.Push(text);
                    text = null;
                }
            }
            else if (c == '[')
            {
                stack.Push(number);
                number = null;
            }
            else if (char.IsLetter(c))
            {
                text += c;
            }
            else if (c == ']')
            {
                var repeat = int.Parse(stack.Pop());
                var temp = text;
                for (var i = 1; i < repeat; i++)
                {
                    text += temp;
                }

                if (stack.Any())
                {
                    text = stack.Pop() + text;
                }
            }
        }

        return text;
    }
}