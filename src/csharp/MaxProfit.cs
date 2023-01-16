public class MaxProfit {

    public static void Run(){
        //var prices = new int[] {7,1,5,3,6,4};
        //var prices = new int[] {7,6,4,3,1};
        //var prices = new int[] {7};
        //var prices = new int[] {1,2};
        var prices = new int[] {2,4,1};
        var d = Run(prices);
    }

    private static int Run(int[] prices) {
        var buyDay = 0;
        var profit = 0;
        for(var i = 1; i < prices.Length; i++)
        {
            if (prices[buyDay] > prices[i])
            {
                buyDay = prices[i];
                buyDay = i;
            }
            else 
            {
                var temp = prices[i] - prices[buyDay];
                if (temp > profit) 
                {
                    profit = temp;
                }
            }
        }

        return profit;
    }
}

