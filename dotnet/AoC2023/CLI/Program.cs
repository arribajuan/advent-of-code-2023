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

Console.WriteLine("Day 2");
Console.WriteLine($" Star 1 - Sum of possible game ids = {sumOfPossibleGameIds}");
Console.WriteLine("-----------------------------");

#endregion