public class IsIsomorphic {

    public static void Run(){
        // var a = Run("egg", "add");
        // var b = Run("foo", "bar");
        // var c = Run("paper", "title");
        //var d = Run("badc", "baba");
        var d = Run("abab", "baba");
    }

    private static bool Run(string s, string t) {
        var map = new Dictionary<char, char>();
        var map1 = new Dictionary<char, char>();
        for (var i = 0; i < s.Length; i++) 
        {
            if (!map.ContainsKey(s[i])){
                map.Add(s[i], t[i]);
            }
            if (!map1.ContainsKey(t[i])){
                map1.Add(t[i], s[i]);
            } 
            else if (map1[t[i]] != s[i]){
                return false;
            }

            if (map[s[i]] != t[i]) {
                return false;
            }
        }

        return true;
    }
}