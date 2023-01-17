//https://leetcode.com/problems/backspace-string-compare/
public class BackspaceCompare {

    public static void Run(){
        //var d = Run("ab#c", "ad#c"); // true
        //var d = Run("ab##", "c#d#"); // true
        //var d = Run("a#c", "b"); // false
        //var d = Run("a##c", "#a#c"); // true
        var d = Run("y#f#o##f", "y#f#o##f"); // true
    }

    private static bool Run(string s, string t) {
        
        Stack<char> GetStack(string str)
        {
            var stack = new Stack<char>();
            foreach(var s in str)
            {
                if (s != '#')
                {
                    stack.Push(s);
                }
                else if (stack.Any())
                {
                    stack.Pop();
                }
            }
            return stack;
        }

        var stackS = GetStack(s);
        var stackT = GetStack(t);

        return stackS.SequenceEqual(stackT);
    }
}

