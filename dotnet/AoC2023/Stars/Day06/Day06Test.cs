namespace Stars.Day06;

public class Day06Test
{
    [Theory]
    [InlineData(0,7, 0)]
    [InlineData(1,6, 6)]
    [InlineData(2,5, 10)]
    [InlineData(3,4, 12)]
    [InlineData(4,3, 12)]
    [InlineData(5,2, 10)]
    [InlineData(6,1, 6)]
    [InlineData(7,0, 0)]
    public void Test_Day06_CalculateDistanceTraveled(int initialSpeed, int availableRaceTime, int expectedDistanceTravelled)
    {
        Assert.Equal(expectedDistanceTravelled , Day06.CalculateDistanceTraveled(initialSpeed, availableRaceTime));
    }

    [Fact]
    public void Test_Day06_SimulateRace()
    {
        var result1 = Day06.SimulateRace(raceTime: 7, distanceRecord: 9);
        var result2 = Day06.SimulateRace(raceTime: 15, distanceRecord: 40);
        var result3 = Day06.SimulateRace(raceTime: 30, distanceRecord: 200);

        Assert.Equal(4, result1.Length);
        
        //if (result1.Length != 4) return;
        //Assert.Equal(2, result1[0]);
        //Assert.Equal(3, result1[1]);
        //Assert.Equal(4, result1[2]);
        //Assert.Equal(5, result1[3]);
        
        Assert.Equal(8, result2.Length);
        Assert.Equal(9, result3.Length);
    }

    [Fact]
    public void Test_Day06_SimulateRaces_Test1()
    {
        var races = new List<Race>();
        races.Add(new Race() { RaceTime = 7, DistanceRecord = 9 });
        races.Add(new Race() { RaceTime = 15, DistanceRecord = 40 });
        races.Add(new Race() { RaceTime = 30, DistanceRecord = 200 });

        var result = Day06.SimulateRaces(races);
        
        Assert.Equal(288, result);
    }
    
    [Fact]
    public void Test_Day06_SimulateRaces_Challenge1()
    {
        var races = new List<Race>();
        races.Add(new Race() { RaceTime = 48, DistanceRecord = 296 });
        races.Add(new Race() { RaceTime = 93, DistanceRecord = 1926 });
        races.Add(new Race() { RaceTime = 85, DistanceRecord = 1236 });
        races.Add(new Race() { RaceTime = 95, DistanceRecord = 1391 });

        var result = Day06.SimulateRaces(races);
        
        Assert.Equal(2756160, result);
    }
    
    [Fact]
    public void Test_Day06_SimulateRaces_Test2()
    {
        var races = new List<Race>();
        races.Add(new Race() { RaceTime = 71530, DistanceRecord = 940200 });

        var result = Day06.SimulateRaces(races);
        
        Assert.Equal(71503, result);
    }
    
    [Fact]
    public void Test_Day06_SimulateRaces_Challenge2()
    {
        var races = new List<Race>();
        races.Add(new Race() { RaceTime = 48938595, DistanceRecord = 296192812361391 });

        var result = Day06.SimulateRaces(races);
        
        Assert.Equal(71503, result);
    }
}