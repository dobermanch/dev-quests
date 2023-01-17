//https://leetcode.com/problems/top-k-frequent-words
public class TopKFrequent {

    public static void Run(){
        //var d = Run(new [] {"i","love","leetcode","i","love","coding"}, 2); // ["i","love"]
        var d = Run(new [] {"the","day","is","sunny","the","the","the","sunny","is","is"}, 4); // ["the","is","sunny","day"]
    }

    private static IList<string> Run(string[] words, int k) 
    {
        return words
            .GroupBy(it => it)
            .OrderByDescending(it => it.Count())
            .ThenBy(it => it.Key)
            .Take(k)
            .Select(it => it.Key)
            .ToArray();
    }
}

