namespace Stars.Day03;

public class SchematicNumber
{
    public int Number { get; set; }
    
    public int Row { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    
    public int BoundaryTopRow { get; set; }
    public int BoundaryLeft { get; set; }
    public int BoundaryRight { get; set; }
    public int BoundaryBottomRow { get; set; }
    
    public bool IsAdjacentToSymbol { get; set; }
}