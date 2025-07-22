using Hearthstone.Game.Players;

namespace Hearthstone.Tests.Players;

public class HealthTests
{
    [Fact]
    public void Should_have_correct_health_When_created()
    {
        var capacity = 100;

        var health = new Health(capacity);

        Assert.Equal(capacity, health.Current);
    }

    [Fact]
    public void Should_have_correct_health_When_after_adding_health()
    {
        var capacity = 100;
        var add = 10;
        var expected = capacity + add;

        var health = new Health(capacity);
        health.Increase(add);

        Assert.Equal(expected, health.Current);
    }

    [Fact]
    public void Should_have_correct_health_When_after_substructing_health()
    {
        var capacity = 100;
        var sub = 10;
        var expected = capacity - sub;

        var health = new Health(capacity);
        health.Decrease(sub);

        Assert.Equal(expected, health.Current);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(-1, true)]
    public void Should_be_dead_When_health_below_or_equial_zero(int capacity, bool expected)
    {
        var health = new Health(capacity);

        Assert.Equal(expected, health.IsDead);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(10, false)]
    public void Should_be_not_dead_When_health_above_zero(int capacity, bool expected)
    {
        var health = new Health(capacity);

        Assert.Equal(expected, health.IsDead);
    }
}
