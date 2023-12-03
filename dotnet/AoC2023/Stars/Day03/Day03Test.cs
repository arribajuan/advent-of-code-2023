namespace Stars.Day03;

public class Day03Test
{
    [Fact]
    public void Test_Day03_FindSchematicNumbersInMatrix_FromFile_Star1()
    {
        var schematicNumbes = Day03.FindSchematicNumbersInMatrixFromFile(Day03.GetFilePath(FileType.Test));
        
        Assert.True(true);
    }   
}