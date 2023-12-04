namespace Stars.Day03;

public class Day03Test
{
    [Fact]
    public void Test_Day03_FindSchematicNumbersInMatrixFromFile_Star1()
    {
        var schematicNumbes = Day03.FindSchematicNumbersInMatrixFromFile(Day03.GetFilePath(FileType.Test));
        
        Assert.Equal(13, schematicNumbes.Count);
    }
    
    [Fact]
    public void Test_Day03_FindSumOfPartNumbersFromFile_Star1()
    {
        var partNumberSum = Day03.FindSumOfPartNumbersFromFile(Day03.GetFilePath(FileType.Test));
        
        Assert.Equal(4361, partNumberSum);
    }   
}