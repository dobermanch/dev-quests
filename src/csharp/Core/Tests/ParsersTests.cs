using LeetCode.Core.Parsers;

namespace LeetCode.Core.Tests;

public class ParsersTests
{
    [Theory]
    [InlineData("[\"1\",\"52\",\"3456\",\"466\"]", new[] { "1", "52", "3456", "466" })]
    [InlineData("[ \"1 \",\" 52\" ,\"3456\",\"466\" ]", new[] { "1 ", " 52", "3456", "466" })]
    [InlineData("[ \"1, \",\" 52\" ,\"3456\",\"466\" ]", new[] { "1, ", " 52", "3456", "466" })]
    [InlineData("""[ "1  "," 52" ,"3456","466" ]""", new[] { "1  ", " 52", "3456", "466" })]
    [InlineData("""[ "1  "," \" " ,"3456","466" ]""", new[] { "1  ", " \" ", "3456", "466" })]
    [InlineData("""[ "1,  "," 52" ,"3456","466" ]""", new[] { "1,  ", " 52", "3456", "466" })]
    [InlineData(""" [ "1,  "," 52" ,"3456","466" ] """, new[] { "1,  ", " 52", "3456", "466" })]
    [InlineData(""" [ "1,  ",," 52" ,"3456","466" ] """, new[] { "1,  ", " 52", "3456", "466" })]
    [InlineData(""" [ "1,  ", ," 52" ,"3456","466" ] """, new[] { "1,  ", "", " 52", "3456", "466" })]
    [InlineData(""" [ "1,  ", null ," 52" ,"3456","466" ] """, new[] { "1,  ", null, " 52", "3456", "466" })]
    [InlineData(""" [] """, new string[0])]
    public void Should_parse_string_array(string input, string[] expected)
    {
        var parser = new StringToArrayParser<string>();

        var result = parser.Parse(input);

        Assert.True(expected.SequenceEqual(result));
    }

    [Theory]
    [InlineData("""["1","52","3456","466"]""", new object[] { 1, 52, 3456, 466 })]
    [InlineData(""" { "1 "," -52" ,"3456","466" } """, new object[] { 1, -52, 3456, 466 })]
    [InlineData(""" [ 1, -52 , 3456,  466  ] """, new object[] { 1, -52, 3456, 466 })]
    [InlineData(""" [1,-52,3456,466]""", new object[] { 1, -52, 3456, 466 })]
    [InlineData(""" [1,,52,3456,466]""", new object[] { 1, 52, 3456, 466 })]
    [InlineData(""" [1, ,52,3456,466]""", new object[] { 1, null, 52, 3456, 466 })]
    [InlineData(""" [1, null ,52,3456,466]""", new object[] { 1, null, 52, 3456, 466 })]
    [InlineData(""" [1, null ,52,"3456",466]""", new object[] { 1, null, 52, 3456, 466 })]
    [InlineData(""" [] """, new object[0])]
    public void Should_parse_null_int_array(string input, object[] expected)
    {
        var parser = new StringToArrayParser<int?>();

        var result = parser.Parse(input);

        Assert.True(expected.Cast<int?>().SequenceEqual(result));
    }

    [Theory]
    [InlineData("""["1","52","3456","466"]""", new [] { 1, 52, 3456, 466 })]
    [InlineData(""" { "1 "," -52" ,"3456","466" } """, new [] { 1, -52, 3456, 466 })]
    [InlineData(""" [ 1, -52 , 3456,  466  ] """, new [] { 1, -52, 3456, 466 })]
    [InlineData(""" [1,-52,3456,466]""", new [] { 1, -52, 3456, 466 })]
    [InlineData(""" [1,,52,3456,466]""", new [] { 1, 52, 3456, 466 })]
    [InlineData(""" [] """, new int[0])]
    public void Should_parse_int_array(string input, int[] expected)
    {
        var parser = new StringToArrayParser<int>();

        var result = parser.Parse(input);

        Assert.True(expected.SequenceEqual(result));
    }

    [Theory]
    [InlineData("""['1','\'',',']""", new object[] { '1', '\'', ',' })]
    [InlineData("""[ '1', '\'' , ',' ]""", new object[] { '1', '\'', ',' })]
    [InlineData(""" ['1', '\'',','] """, new object[] { '1', '\'', ',' })]
    [InlineData(""" [] """, new object[0])]
    public void Should_parse_char_array(string input, object[] expected)
    {
        var parser = new StringToArrayParser<char?>();

        var result = parser.Parse(input);

        Assert.True(expected.Cast<char?>().SequenceEqual(result));
    }

    [Theory]
    [InlineData("""[true,false,null]""", new object[] { true, false, null })]
    [InlineData("""[ true , false,null ]""", new object[] { true, false, null })]
    [InlineData(""" [true,false,null] """, new object[] { true, false, null })]
    [InlineData(""" [] """, new object[0])]
    public void Should_parse_bool_array(string input, object[] expected)
    {
        var parser = new StringToArrayParser<bool?>();

        var result = parser.Parse(input);

        Assert.True(expected.Cast<bool?>().SequenceEqual(result));
    }

    [Theory]
    [InlineData("""[true,1,'2',"dd",null]""", new object[] { true, 1, '2', "dd", null})]
    [InlineData("""[ true , 1, '2' ,"dd" ,null]""", new object[] { true, 1, '2', "dd", null })]
    [InlineData(""" [ true , 1, '2' ,"dd" ,null] """, new object[] { true, 1, '2', "dd", null })]
    [InlineData(""" [] """, new object[0])]
    public void Should_parse_object_array(string input, object[] expected)
    {
        var parser = new StringToArrayParser<object?>();

        var result = parser.Parse(input);

        Assert.True(expected.SequenceEqual(result));
    }

    [Theory]
    [InlineData("""[[2],[2,1],[1,1]]""", new object[] { new int[] { 2 }, new int[] { 2, 1 }, new int[] { 1, 1 } })]
    [InlineData(""" [ [2] , [2,1] , [1,1] ] """, new object[] { new int[] { 2 }, new int[] { 2, 1 }, new int[] { 1, 1 } })]
    [InlineData(""" [ [ 2 ] , [2 ,1 ] , [ 1 , 1 ] ] """, new object[] { new int[] { 2 }, new int[] { 2, 1 }, new int[] { 1, 1 } })]
    [InlineData(""" [] """, new object[0])]
    public void Should_parse_2d_array(string input, object expected)
    {
        var parser = new StringTo2dArrayParser<int>();

        var result = parser.Parse(input);

        var arr = ((object[])expected).Cast<int[]>().Select((it, index) => new { arr = it, index }).ToArray();

        Assert.True(arr.All(it => result[it.index].SequenceEqual(it.arr)));
    }

    [Theory]
    [InlineData("""[["esgriv.com"],[9],['7','8']]""", new object[] { new object[] { "esgriv.com" }, new object[] { 9 }, new object[] { '7', '8' } })]
    [InlineData(""" [] """, new object[0])]
    public void Should_parse_2d_object_array(string input, object expected)
    {
        var parser = new StringTo2dArrayParser<object>();

        var result = parser.Parse(input);

        var arr = ((object[])expected).Cast<object[]>().Select((it, index) => new { arr = it, index }).ToArray();

        Assert.True(arr.All(it => result[it.index].SequenceEqual(it.arr)));
    }
}
