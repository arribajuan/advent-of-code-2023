using System.Collections.Concurrent;
using System.Diagnostics;

namespace Stars.Day06;

public class Day06
{
    public static long SimulateRaces(List<Race> races)
    {
        if (races.Count == 0) return 0;

        long marginOfError = 1;
        foreach (Race race in races)
        {
            race.WinninOptionCount = SimulateRace(race.RaceTime, race.DistanceRecord);
            marginOfError *= race.WinninOptionCount;
        }

        return marginOfError;
    }

    public static long SimulateRace(long raceTime, long distanceRecord)
    {
        var winningOptions = new ConcurrentBag<long>();
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

        return winningOptions.ToArray().Length;
    }

    public static long CalculateDistanceTraveled(long currentSpeed, long availableRaceTime)
    {
        return currentSpeed * availableRaceTime;
    }
}