using System.Collections.Concurrent;

namespace Stars.Day06;

public class Day06
{
    public static int SimulateRaces(List<Race> races)
    {
        if (races.Count == 0) return 0;
        
        var marginOfError = 1;
        foreach (Race race in races)
        {
            race.WinningOptions = SimulateRace(race.RaceTime, race.DistanceRecord);
            marginOfError *= race.WinningOptions.Length;
        }

        return marginOfError;
    } 
    
    public static int[] SimulateRace(int raceTime, long distanceRecord)
    {
        
        var winningOptions = new ConcurrentBag<int>();
        Parallel.For(0, raceTime, i =>
        {
            var availableTime = raceTime - i;
            var windupTime = i;
            var distanceTravelled = CalculateDistanceTraveled(windupTime, availableTime);

            if (distanceTravelled > distanceRecord)
            {
                winningOptions.Add(i);
            }
        });
        
        /*
        var winningOptions = new List<int>();
        for (var i = 0; i < raceTime; i++)
        {
            var availableTime = raceTime - i;
            var windupTime = i;
            var distanceTravelled = CalculateDistanceTraveled(windupTime, availableTime);

            if (distanceTravelled > distanceRecord)
            {
                winningOptions.Add(i);
            }
        }
        */
        
        return winningOptions.ToArray();
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