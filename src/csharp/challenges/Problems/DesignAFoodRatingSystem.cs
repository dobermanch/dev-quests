//https://leetcode.com/problems/design-a-food-rating-system


namespace LeetCode.Problems;

public sealed class MyFoodRatings : ProblemBase
{
    [Theory]
    [ClassData(typeof(MyFoodRatings))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases() 
        => Instructions<FoodRatings, object[]>(config =>
                config
                    .MapConstructor("FoodRatings", data => 
                        {
                            var instance = new FoodRatings(data[0].Cast<string>().ToArray(), data[1].Cast<string>().ToArray(), data[2].Cast<int>().ToArray());
                            data.RemoveAt(0);
                            data.RemoveAt(0);
                            return instance;
                        })
                    .MapInstruction("highestRated", (it, data) => it.HighestRated((string)data[0]))
                    .MapInstruction("changeRating", (it, data) => it.ChangeRating((string)data[0], (int)data[1]))
            )
            .Add(tc =>
                  tc.Data<object>("""[[["kimchi","miso","sushi","moussaka","ramen","bulgogi"],["korean","japanese","japanese","greek","japanese","korean"],[9,12,8,15,14,7]],["korean"],["japanese"],["sushi",16],["japanese"],["ramen",16],["japanese"]]""")
                    .Instructions("""["FoodRatings", "highestRated", "highestRated", "changeRating", "highestRated", "changeRating", "highestRated"]""")
                    .Output("""[null, "kimchi", "ramen", null, "sushi", null, "ramen"]""")
            );

    internal class FoodRatings
    {
        private readonly Dictionary<string, FoodItem> _byFood;
        private readonly Dictionary<string, SortedSet<FoodItem>> _byCuisines;

        public FoodRatings(string[] foods, string[] cuisines, int[] ratings) 
        {
            var menu = foods
                    .Zip(cuisines, ratings)
                    .Select(it => new FoodItem(it.First, it.Second) { Rating = it.Third})
                    .ToArray();

            _byFood = menu.ToDictionary(it => it.Food, it => it);

            _byCuisines = menu
                .GroupBy(it => it.Cuisine)
                .ToDictionary(it => it.Key, it => new SortedSet<FoodItem>(it.ToArray()));
        }

        public void ChangeRating(string food, int newRating) 
        {
            var item = _byFood[food];
            _byCuisines[item.Cuisine].Remove(item);

            item.Rating = newRating;

            _byCuisines[item.Cuisine].Add(item);
        }

        public string HighestRated(string cuisine) 
            => _byCuisines[cuisine].First().Food;

        record FoodItem(string Food, string Cuisine) : IComparable<FoodItem>
        {
            public int Rating { get; set; }

            public int CompareTo(FoodItem? other)
            {
                int result = Rating.CompareTo(other!.Rating);
                return result != 0 ? result * -1 : Food.CompareTo(other.Food);
            }
        }
    }
}