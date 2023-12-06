namespace Helpers;

public class ParseTest
{
    [Fact]
    public void Test_FileIO_Load2DArrayFromTextLinesDay3_Empty()
    {
        var emptyInput = new List<string>();
        var emptyResult = new string [0, 0];
        var resultData = Parse.Load2DArrayFromTextLinesDay3(emptyInput);
        
        Assert.Equal(emptyResult, resultData);
    }

    [Fact]
    public void Test_FileIO_Load2DArrayFromTextLinesDay3()
    {
        var lines = new List<string>
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };

        var resultData = Parse.Load2DArrayFromTextLinesDay3(lines);
        
        Assert.Equal(2, resultData.Rank);
        Assert.Equal(10, resultData.GetLength(0));
        Assert.Equal(10, resultData.GetLength(1));
    }

    [Fact]
    public void Test_FileIO_Load2DArrayFromTextLinesDay5_Empty()
    {
        var emptyInput = new List<string>();
        var emptyResult = new int [0, 0];
        var resultData = Parse.Load2DArrayFromTextLinesDay5(emptyInput);
        
        Assert.Equal(emptyResult, resultData);
    }
    
    [Fact]
    public void Test_FileIO_Load2DArrayFromTextLinesDay5()
    {
        var lines = new List<string>
        {
            "50 98 2 ",
            "52 50 48"
        };

        var resultData = Parse.Load2DArrayFromTextLinesDay5(lines);
        
        Assert.Equal(2, resultData.Rank);
        Assert.Equal(2, resultData.GetLength(0));
        Assert.Equal(3, resultData.GetLength(1));
    }
}