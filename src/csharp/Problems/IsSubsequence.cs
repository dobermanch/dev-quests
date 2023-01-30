namespace LeetCode.Problems;

public sealed class IsSubsequence : ProblemBase
{
    public static void Run(){
        var d = Run("abc", "ahbgdc");
    }

    private static bool Run(string s, string t) {
        if (string.IsNullOrEmpty(s)) 
        {
            return true;
        }

        if (string.IsNullOrEmpty(t)) 
        {
            return false;
        }

        var j = 0;
        for (var i = 0; i < t.Length; i++)
        {
            if (t[i] == s[j]) 
            {
                j++;
                if (j >= s.Length) 
                {
                    break;
                }
            }
        }

        return j == s.Length;
    }
}