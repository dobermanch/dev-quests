public class LongestPalindrome {

    public static void Run(){
        var d = Run("zbccccdd");
    }

    private static int Run(string s) {
        var map = new int[58];

        for (var i = 0; i < s.Length; i++) 
        {
            map[s[i] - 'A']++;
        }

        var sum = 0;
        var addOne = false;
        for (var i = 0; i < map.Length; i++) 
        {
            if (map[i] % 2 == 0)
            {
                sum += map[i];
            }
            else
            {
                sum += map[i] - 1;
                addOne = true;
            }
        }

        return addOne ? ++sum : sum;
        // var map = new Dictionary<char, int>();

        // for (var i = 0; i < s.Length; i++) 
        // {
        //     if (!map.ContainsKey(s[i]))
        //     {
        //         map.Add(s[i], 0);
        //     }

        //     map[s[i]]++;
        // }

        // var sum = 0;
        // var addOne = false;
        // foreach(var i in map)
        // {
        //     if (i.Value % 2 == 0)
        //     {
        //         sum += i.Value;
        //     }
        //     else
        //     {
        //         sum += i.Value - 1;
        //         addOne = true;
        //     }
        // }

        // return addOne ? ++sum : sum;
    }
}

