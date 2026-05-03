using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        
        List<double> data = new List<double>()
        {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110
        };

      
        List<double> sortedData = data.OrderBy(x => x).ToList();
        int n = sortedData.Count;

       
        double mean = sortedData.Average();

       
        double mode = GetMode(sortedData);

       
        double median = GetPercentile(sortedData, 50);

        
        double variance = sortedData.Select(x => Math.Pow(x - mean, 2)).Sum() / (n - 1);

       
        double p20 = GetPercentile(sortedData, 20);

        
        double p50 = median;

        
        double thirdQuartile = GetPercentile(sortedData, 75);

        
        double range = sortedData.Max() - sortedData.Min();

        
        double q1 = GetPercentile(sortedData, 25);
        double iqr = thirdQuartile - q1;

        
        double stdDev = Math.Sqrt(variance);

       
        double sumDeviations = sortedData.Select(x => x - mean).Sum();

        
        Console.WriteLine("=== Statistical Summary ===");
        Console.WriteLine($"i) Mean: {mean:F4}");
        Console.WriteLine($"ii) Mode: {mode}");
        Console.WriteLine($"iii) Median: {median}");
        Console.WriteLine($"iv) Variance: {variance:F4}");
        Console.WriteLine($"v) P20: {p20}");
        Console.WriteLine($"vi) P50: {p50}");
        Console.WriteLine($"vii) Third Quartile: {thirdQuartile}");
        Console.WriteLine($"viii) Second Quartile: {median}");
        Console.WriteLine($"ix) Third Quartile: {thirdQuartile}");
        Console.WriteLine($"x) Range: {range}");
        Console.WriteLine($"xi) Interquartile Range (IQR): {iqr}");
        Console.WriteLine($"xii) Standard Deviation: {stdDev:F4}");
        Console.WriteLine($"xiii) Summation of Deviations: {sumDeviations:F4}");
    }

    static double GetMode(List<double> data)
    {
        return data.GroupBy(v => v)
                   .OrderByDescending(g => g.Count())
                   .First()
                   .Key;
    }

    static double GetPercentile(List<double> sortedData, double percentile)
    {
        double position = (percentile / 100.0) * (sortedData.Count - 1);
        int leftIndex = (int)Math.Floor(position);
        int rightIndex = (int)Math.Ceiling(position);

        if (leftIndex == rightIndex)
        {
            return sortedData[leftIndex];
        }

        double fraction = position - leftIndex;
        return sortedData[leftIndex] + fraction * (sortedData[rightIndex] - sortedData[leftIndex]);
    }

}
