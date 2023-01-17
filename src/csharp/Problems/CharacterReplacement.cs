public class CharacterReplacement {

    public static void Run(){
        var d = Run("AABABBA", 1); //4
        //var d = Run("AAAA", 2); //4
        //var d = Run("ABAA", 0); //2
        //var d = Run("ABBB", 2); //2
    }

    private static int Run(string s, int k) {
        var map = new int[26];

        var sum = 0;
        var marker = s[0];
        for (int i = 0; i < s.Length; i++)
        {
            map[s[i] - 'A']++;

            if (marker != s[i])
            {
                
            }
        }

        return sum;
    }

    private static char Next(int[] map, int current)
    {
        var ch = 0;
        var sum = 0;
        for (int i = 0; i < map.Length - 1; i++)
        {
            if (map[i] < current && map[i] > sum)
            {
                sum = map[i];
                ch = i;
            }
        }

        return (char)(ch + 'A');
    }
}

