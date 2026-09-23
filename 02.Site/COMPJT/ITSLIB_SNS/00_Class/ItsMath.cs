using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ItsMath
{
    public static decimal Round(decimal number, int digits)
    {
        decimal n = (decimal)(Math.Pow(10.0, digits));
        return Math.Floor(number * n + 0.5m) / n;
    }
    public static decimal RoundCheck(decimal number, int digits)
    {
        decimal n = (decimal)(Math.Pow(10.0, digits));
        return Math.Round(number * n) / n;
    }
    public static decimal RoundDown(decimal number, int digits)
    {
        decimal n = (decimal)(Math.Pow(10.0, digits));
        return Math.Floor(number * n) / n;
    }
    public static decimal RoundUp(decimal number, int digits)
    {
        decimal n = (decimal)(Math.Pow(10.0, digits));
        return Math.Ceiling(number * n) / n;
    }
    public static decimal Max(params object[] numbers)
    {
        decimal maxNumber = 0;
        foreach (object obj in numbers)
        {
            try
            {
                decimal targetNumber = decimal.Parse(obj.ToString());
                if (targetNumber > maxNumber) maxNumber = targetNumber;
            }
            catch { }
        }
        return maxNumber;
    }
    public static decimal Min(params object[] numbers)
    {
        decimal minNumber = 0;
        foreach (object obj in numbers)
        {
            try
            {
                decimal targetNumber = decimal.Parse(obj.ToString());
                if (targetNumber < minNumber) minNumber = targetNumber;
            }
            catch { }
        }
        return minNumber;
    }
    public static decimal Ave(params object[] numbers)
    {
        decimal sumNumber = 0;
        int count = 0;
        foreach (object obj in numbers)
        {
            try
            {
                decimal targetNumber = decimal.Parse(obj.ToString());
                sumNumber += targetNumber;
                count++;
            }
            catch { }
        }
        return sumNumber / count;
    }
    public static decimal Sum(params object[] numbers)
    {
        decimal sumNumber = 0;
        foreach (object obj in numbers)
        {
            try
            {
                decimal targetNumber = decimal.Parse(obj.ToString());
                sumNumber += targetNumber;
            }
            catch { }
        }
        return sumNumber;
    }
}
