namespace Stars.Day05;

public class Day05Test
{
    [Fact]
    public void Test_Day05_ParseAlmanac_FromFile()
    {
        var almanac = Day05.ParseAlmanacFromFile(Day05.GetFilePath(FileType.Test));
        
        Assert.NotNull(almanac);
    }
}