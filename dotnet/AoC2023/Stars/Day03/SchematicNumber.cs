namespace Stars.Day03;

public class SchematicNumber
{
    public int Number { get; set; }
    
    public int Row { get; set; }
    public int Start { get; set; }
    public int Length { get; set; }
    public bool IsAdjacentToSymbol { get; set; }
}