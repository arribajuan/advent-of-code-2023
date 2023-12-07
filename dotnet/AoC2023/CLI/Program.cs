// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello there!");
Console.WriteLine("-----------------------------");

#region Day 1

var d01SumCalibrationValuesStar1 = Stars.Day01.Day01.SumCalibrationValuesFromFile(Stars.Day01.Day01.GetFilePath(Stars.Day01.FileType.ChallengeData), false);
var d01SumCalibrationValuesStar2 = Stars.Day01.Day01.SumCalibrationValuesFromFile(Stars.Day01.Day01.GetFilePath(Stars.Day01.FileType.ChallengeData), true);

Console.WriteLine("Day 1");
Console.WriteLine($" Star 1 - CalibrationValues = {d01SumCalibrationValuesStar1}");
Console.WriteLine($" Star 2 - CalibrationValues = {d01SumCalibrationValuesStar2}");
Console.WriteLine("-----------------------------");

#endregion

#region Day 2

var gameBudget = new Stars.Day02.GameBudget { AvailableRedBalls = 12, AvailableGreenBalls = 13, AvailableBlueBalls = 14 };
var sumOfPossibleGameIds = Stars.Day02.Day02.FindSumOfPossibleGameIdsFromFile(Stars.Day02.Day02.GetFilePath(Stars.Day02.FileType.ChallengeData), gameBudget);
var sumOfPowerOfTheMinimumSetOfBalls = Stars.Day02.Day02.FindSumOfPowerOfTheMinimumSetOfBallsFromFile(Stars.Day02.Day02.GetFilePath(Stars.Day02.FileType.ChallengeData));

Console.WriteLine("Day 2");
Console.WriteLine($" Star 1 - Sum of possible game ids = {sumOfPossibleGameIds}");
Console.WriteLine($" Star 2 - Sum of power of the minimum set of balls = {sumOfPowerOfTheMinimumSetOfBalls}");
Console.WriteLine("-----------------------------");

#endregion

#region Day 3

var sumOfNumberParts = Stars.Day03.Day03.FindSumOfPartNumbersFromFile(Stars.Day03.Day03.GetFilePath(Stars.Day03.FileType.ChallengeData));
var sumOfGearRatios = Stars.Day03.Day03.FindSumOfGearRatiosFromFile(Stars.Day03.Day03.GetFilePath(Stars.Day03.FileType.ChallengeData));

Console.WriteLine("Day 3");
Console.WriteLine($" Star 1 - Sum of part numbers = {sumOfNumberParts}");
Console.WriteLine($" Star 2 - Sum of gear ratios = {sumOfGearRatios}");
Console.WriteLine("-----------------------------");

#endregion

#region Day 4

var pointsInCardPile = Stars.Day04.Day04.CalculatePointsInCardPileFromFile(Stars.Day04.Day04.GetFilePath(Stars.Day04.FileType.ChallengeData));
var totalCards = Stars.Day04.Day04.CalculateTotalCardsFromFile(Stars.Day04.Day04.GetFilePath(Stars.Day04.FileType.ChallengeData));

Console.WriteLine("Day 4");
Console.WriteLine($" Star 1 - Sum of points in card pile = {pointsInCardPile}");
Console.WriteLine($" Star 2 - Total cards = {totalCards}");
Console.WriteLine("-----------------------------");

#endregion

#region Day 5

Console.WriteLine("-----------------------------");
Console.WriteLine("Day 5");
Console.WriteLine("Start - " + DateTime.Now);

var almanac = Stars.Day05.Day05.ParseAlmanacFromFile(Stars.Day05.Day05.GetFilePath(Stars.Day05.FileType.ChallengeData));
Console.WriteLine("Parse complete - " + DateTime.Now);

var locations1 = Stars.Day05.Day05.FindLocationsForAlmanacSeeds(almanac, Stars.Day05.SeedType.Normal);
Console.WriteLine($" Star 1 - Lowest location number = {locations1.Min()} - " + DateTime.Now);

var locations2 = Stars.Day05.Day05.FindLocationsForAlmanacSeeds(almanac, Stars.Day05.SeedType.Extended);
Console.WriteLine($" Star 2 - Lowest location number (extended seeds) = {locations2.Min()} - " + DateTime.Now);

Console.WriteLine("-----------------------------");

#endregion
