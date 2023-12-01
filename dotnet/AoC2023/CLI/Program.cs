// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello there!");
Console.WriteLine("-----------------------------");

#region Day 1

var d01 = new Stars.Day01.Day01();
var d01SumCalibrationValues = d01.SumCalibrationValuesFromFile();

Console.WriteLine("Day 1");
Console.WriteLine($" Star 1 - CalibrationValues = {d01SumCalibrationValues}");
Console.WriteLine("-----------------------------");

#endregion