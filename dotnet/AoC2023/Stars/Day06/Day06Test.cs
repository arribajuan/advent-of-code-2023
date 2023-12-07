namespace Stars.Day06;

public class Day06Test
{
    [Theory]
    [InlineData(0,7, 0)]
    [InlineData(1,6, 6)]
    [InlineData(2,5, 10)]
    [InlineData(3,4, 12)]
    [InlineData(4,3, 12)]
    [InlineData(5,2, 10)]
    [InlineData(6,1, 6)]
    [InlineData(7,0, 0)]
    public void Test_Day06_CalculateDistanceTraveled(int initialSpeed, int availableRaceTime, int expectedDistanceTravelled)
    {
        Assert.Equal(expectedDistanceTravelled , Day06.CalculateDistanceTraveled(initialSpeed, availableRaceTime));
    }
    
}