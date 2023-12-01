namespace Stars.Day01;

public class Day01Test
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void Test_Day01_CalculateFinalFloor_SampleDirections(string text, int calibrationValue)
    {
        var d01 = new Day01();
        Assert.Equal(calibrationValue , d01.FindCalibrationValue(text));
    }
}