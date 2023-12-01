namespace Helpers;

public class FileIOTest
{
    
    [Fact]
    public void Test_FileIO_LoadTextFromFile_NoFile()
    {
        var emptyData = string.Empty;
        
        var fio = new FileIO();
        var resultData = fio.LoadTextFromFile("");
        
        Assert.Equal(emptyData, resultData);
    }
    
    [Fact]
    public void Test_FileIO_LoadTextFromFile()
    {
        var testDataPath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/test-data.txt";
        
        var fio = new FileIO();
        var resultData = fio.LoadTextFromFile(testDataPath);
        
        Assert.NotEmpty(resultData);
        Assert.Equal(13, resultData.Length);
    }
    
    
    [Fact]
    public void Test_FileIO_LoadTextLinesFromFile_NoFile()
    {
        var emptyData = new List<string>();
        
        var fio = new FileIO();
        var resultData = fio.LoadTextLinesFromFile("");
        
        Assert.Equal(emptyData, resultData);
    }

    [Fact]
    public void Test_FileIO_LoadTextLinesFromFile()
    {
        var testDataPath = AppDomain.CurrentDomain.BaseDirectory + "assets/data/test-data.txt";
        
        var fio = new FileIO();
        var resultData = fio.LoadTextLinesFromFile(testDataPath);
        
        Assert.NotEmpty(resultData);
        Assert.Equal(2, resultData.Count);
    }
    
}