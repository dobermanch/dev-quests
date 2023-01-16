//https://leetcode.com/problems/climbing-stairs/description
class ClimbStairs {

    public static int Run(){
        var result = Fib(10);

        return result;
    }

    private static int Fib(int n)
    {
        if (n == 1 || n == 0)
        {
            return n;
        }

        var t0 = 0;
        var t1 = 1;
        while(n > 0)
        {
            var temp = t1;
            t1 = t1 + t0;
            t0 = temp;
        }

        return t1;
    }
}

