namespace Stars.Day01;

public class Day01Test
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void Test_Day01_FindCalibrationValues_Star1(string text, int calibrationValue)
    {
        var d01 = new Day01();
        Assert.Equal(calibrationValue , d01.FindCalibrationValue(text));
    }
    
    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void Test_Day01_FindCalibrationValues_Star2(string text, int calibrationValue)
    {
        var d01 = new Day01();
        Assert.Equal(calibrationValue , d01.FindCalibrationValue(text));
    }
    
    [Fact]
    public void Test_Day01_FindCalibrationValues_FromFile()
    {
        var d01 = new Day01();
        var totalCalibrationValue = d01.SumCalibrationValuesFromFile(Day01.GetFilePath(FileType.Test));
        
        Assert.Equal(142, totalCalibrationValue);
    }
}