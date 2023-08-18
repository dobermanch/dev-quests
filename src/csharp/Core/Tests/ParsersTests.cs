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
        var parser = new StringToArrayParser<string>(new StringValueParser());

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
        var parser = new StringToArrayParser<int?>(new NullIntValueParser());

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
        var parser = new StringToArrayParser<int>(new IntValueParser());

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
        var parser = new StringToArrayParser<char?>(new CharValueParser());

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
        var parser = new StringToArrayParser<bool?>(new BoolValueParser());

        var result = parser.Parse(input);

        Assert.True(expected.Cast<bool?>().SequenceEqual(result));
    }
}
