// See https://aka.ms/new-console-template for more information

using Stars.Day01;

Console.WriteLine("Hello there!");
Console.WriteLine("-----------------------------");

#region Day 1

var d01SumCalibrationValuesStar1 = Day01.SumCalibrationValuesFromFile(Day01.GetFilePath(FileType.ChallengeData), false);
var d01SumCalibrationValuesStar2 = Day01.SumCalibrationValuesFromFile(Day01.GetFilePath(FileType.ChallengeData), true);

Console.WriteLine("Day 1");
Console.WriteLine($" Star 1 - CalibrationValues = {d01SumCalibrationValuesStar1}");
Console.WriteLine($" Star 2 - CalibrationValues = {d01SumCalibrationValuesStar2}");
Console.WriteLine("-----------------------------");

#endregion