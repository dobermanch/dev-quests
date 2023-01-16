public class FindAnagrams {

    public static void Run(){
        var d = Run("cbaebabacd", "abc");
    }

//Option2
    private static IList<int> Run(string s, string p) {
        if (p.Length > s.Length)
        {
            return Array.Empty<int>();
        }

        var anagram = new int[26];
        for (var i = 0; i < p.Length; i++)
        {
            anagram[p[i] - 'a']++;
        }

        var result = new List<int>();
        var temp = new int[26];
        for (var i = 0; i < s.Length; i++)
        {
            temp[s[i] - 'a']++;

            if (i >= p.Length - 1)
            {
                var index = i - (p.Length - 1);
                if (anagram.SequenceEqual(temp))
                {
                    result.Add(index);
                }

                temp[s[index] - 'a']--;
            }
        }

        return result;
    }

//Option1
    private static IList<int> Run1(string s, string p) {
        if (p.Length > s.Length)
        {
            return Array.Empty<int>();
        }

        var result = new List<int>();
        var map = new int[26];
        for (var i = 0; i < p.Length; i++)
        {
            map[p[i] - 'a'] += 1;
        }

        var lenght1 = s.Length - p.Length;
        for (var i = 0; i <= lenght1; i++)
        {
            if (map[s[i] - 'a'] <= 0)
            {
                continue;
            }

            var temp = map.ToArray();
            var count = 0;
            for (var j = i; j < i + p.Length; j++)
            {
                if (--temp[s[j] - 'a'] < 0)
                {
                    break;
                }
                count++;
            }

            if (count == p.Length)
            {
                result.Add(i);
            }
        }

        return result;
    }
}

