//https://leetcode.com/problems/flip-string-to-monotone-increasing/description/
public class MinFlipsMonoIncr {

    public static void Run(){
        //var d = Run("100100111110000010010111011");
        var d = Run("0000001111100100010010111011");
        //var d = Run("10011111110010111011");
    }

    private static int Run(string s) {
        var flips = 0;

        var zeros = 0;
        var ones = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                ones++;
            }
            else if (++zeros > ones)
            {
                flips += ones;
                ones = 0;
                zeros = 0;
            }
        }

        flips += ones > zeros ? zeros : ones;

        return flips;
    }
}

