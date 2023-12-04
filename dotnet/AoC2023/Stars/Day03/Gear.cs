namespace Stars.Day03;

public class Gear
{
    public int Row {get; set; }
    public int Column { get; set; }
    
    public int BoundaryTopRow { get; set; }
    public int BoundaryLeft { get; set; }
    public int BoundaryRight { get; set; }
    public int BoundaryBottomRow { get; set; }
    
    public List<int> AdjacentPartNumbers { get; set; } = new();
    
    public int GearRatio { get; set; }
}