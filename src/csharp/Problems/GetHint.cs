//https://leetcode.com/problems/bulls-and-cows/description
public class GetHint {

    public static void Run(){
        //var d = Run("1807", "7810"); // 1A3B
        //var d = Run("1123", "0111"); // 1A1B
        //var d = Run("1122", "2211"); // 1A1B
        var d = Run("1122", "1222"); // 3A0B
        //var d = Run("11225", "22111"); // 0A4B
    }

    private static string Run(string secret, string guess)
    {
        var map = new int[10, 2];

        var bulls = 0;
        var cows = 0;
        for(var i = 0; i < guess.Length; i++)
        {
            if (guess[i] == secret[i])
            {
                bulls++;
            }
            else
            {
                map[secret[i] - '0', 0]++;
                map[guess[i] - '0', 1]++;
            }
        }

        for(var i = 0; i < map.GetLength(0); i++)
        {
            cows += Math.Min(map[i, 0], map[i, 1]);
        }

        return $"{bulls}A{cows}B";
    }
}