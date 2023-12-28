//https://leetcode.com/problems/add-binary

namespace LeetCode.Problems;

public sealed class AddBinary : ProblemBase
{
    [Theory]
    [ClassData(typeof(AddBinary))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("1101010").Param("111").Result("1110001"))
          .Add(it => it.Param("11").Param("1").Result("100"))
          .Add(it => it.Param("1010").Param("1011").Result("10101"))
          .Add(it => it.Param("1101010").Param("10000111").Result("11110001"));

    private string Solution(string a, string b)
    {
        if (a.Length > b.Length)
        {
            b = b.PadLeft(a.Length, '0');
        }
        else
        {
            a = a.PadLeft(b.Length, '0');
        }

        var result = new StringBuilder();

        var carry = 0;
        for (var i = a.Length - 1; i >= 0; i--)
        {
            char bit;
            (bit, carry) = (a[i] - '0' + b[i] - '0' + carry) switch
            {
                3 => ('1', 1),
                2 => ('0', 1),
                1 => ('1', 0),
                _ => ('0', 0)
            };

            result.Insert(0, bit);
        }

        if (carry == 1)
        {
            result.Insert(0, carry);
        }

        return result.ToString();

        //(bit, carry) = (a[i], b[i], carry) switch
        //{
        //    ('1', '1', 0) or ('1', '0', 1) or ('0', '1', 1) => ('0', 1),
        //    ('1', '1', 1) => ('1', 1),
        //    ('1', '0', 0) or ('0', '1', 0) or ('0', '0', 1) => ('1', 0),
        //    _ => ('0', 0)
        //};
    }
}