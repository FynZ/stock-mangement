using Xunit;

namespace StockManagement.Tests;

public class UnitTest
{
    [Fact]
    public void Fact()
    {
        Assert.True(true);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void Theory(bool expected, bool actual)
    {
        Assert.Equal(expected, actual);
    }
}
