namespace Stars.Day06;

public class Day06
{
    public static int SimulateRace(Boat boat)
    {
        return 0;
    }

    public static int CalculateDistanceTraveled(int currentSpeed, int availableRaceTime)
    {
        var distanceTravelled = 0;
        for (var i = 0; i < availableRaceTime; i++)
        {
            distanceTravelled += currentSpeed;
        }
        
        return distanceTravelled;
    }
}