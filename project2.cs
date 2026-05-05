using System;
using System.Collections.Generic;
using System.Linq;

class OutlierAnalyzer
{
    static void Main()
    {
       
        List<double> inputData = new List<double>()
        {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110
        };

        List<double> sortedData = inputData.OrderBy(val => val).ToList();

       
        double q1 = CalculatePercent(sortedData, 25);
        double q3 = CalculatePercent(sortedData, 75);

      
        double iqr = q3 - q1;

       
        double lowerLimit = q1 - 1.5 * iqr;
        double upperLimit = q3 + 1.5 * iqr;

        Console.WriteLine("=== Outlier Detection ===");
        Console.WriteLine($"Q1: {q1}, Q3: {q3}, IQR: {iqr}");
        Console.WriteLine($"Acceptable Range: {lowerLimit} to {upperLimit}\n");

        Console.WriteLine("Data Evaluation:");
        foreach (var num in inputData)
        {
            if (num < lowerLimit || num > upperLimit)
            {
                Console.WriteLine($"- Number {num} => Outlier");
            }
            else
            {
                Console.WriteLine($"- Number {num} => Normal");
            }
        }
    }

    static double CalculatePercent(List<double> sortedValues, double percentile)
    {
        double indexPosition = (percentile / 100.0) * (sortedValues.Count - 1);
        int minIndex = (int)Math.Floor(indexPosition);
        int maxIndex = (int)Math.Ceiling(indexPosition);

        if (minIndex == maxIndex)
        {
            return sortedValues[minIndex];
        }

        double difference = indexPosition - minIndex;
        return sortedValues[minIndex] + difference * (sortedValues[maxIndex] - sortedValues[minIndex]);
    }
}
