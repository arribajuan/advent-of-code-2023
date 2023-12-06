namespace Helpers;

public class FileIOTest
{
    
    [Fact]
    public void Test_FileIO_LoadTextFromFile_NoFile()
    {
        var emptyData = string.Empty;
        var resultData = FileIO.LoadTextFromFile("");
        
        Assert.Equal(emptyData, resultData);
    }
    
    [Fact]
    public void Test_FileIO_LoadTextFromFile()
    {
        var testDataPath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/test-data.txt";
        var resultData = FileIO.LoadTextFromFile(testDataPath);
        
        Assert.NotEmpty(resultData);
        Assert.Equal(13, resultData.Length);
    }
    
    
    [Fact]
    public void Test_FileIO_LoadTextLinesFromFile_NoFile()
    {
        var emptyData = new List<string>();
        var resultData = FileIO.LoadTextLinesFromFile("");
        
        Assert.Equal(emptyData, resultData);
    }

    [Fact]
    public void Test_FileIO_LoadTextLinesFromFile()
    {
        var testDataPath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/test-data.txt";
        var resultData = FileIO.LoadTextLinesFromFile(testDataPath);
        
        Assert.NotEmpty(resultData);
        Assert.Equal(2, resultData.Count);
    }
    
    
    [Fact]
    public void Test_FileIO_Load2DArrayFromFileDay3_NoFile()
    {
        var emptyData = new string[0, 0];
        var resultData = FileIO.Load2DArrayFromFileDay3("");
        
        Assert.Equal(emptyData, resultData);
    }

    [Fact]
    public void Test_FileIO_Load2DArrayFromFileDay3()
    {
        var testDataPath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/test-2darray-day3.txt";
        var resultData = FileIO.Load2DArrayFromFileDay3(testDataPath);
        
        Assert.Equal(2, resultData.Rank);
        Assert.Equal(10, resultData.GetLength(0));
        Assert.Equal(10, resultData.GetLength(1));
    }
    
    [Fact]
    public void Test_FileIO_Load2DArrayFromFileDay5_NoFile()
    {
        var emptyData = new int[0, 0];
        var resultData = FileIO.Load2DArrayFromFileDay5("");
        
        Assert.Equal(emptyData, resultData);
    }

    [Fact]
    public void Test_FileIO_Load2DArrayFromFileDay5()
    {
        var testDataPath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/test-2darray-day5.txt";
        var resultData = FileIO.Load2DArrayFromFileDay5(testDataPath);
        
        Assert.Equal(2, resultData.Rank);
        Assert.Equal(2, resultData.GetLength(0));
        Assert.Equal(3, resultData.GetLength(1));
    }
}