﻿namespace MediatorPattern;
internal interface ILogger
{
    void Log(string message);
}
internal class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[{TimeOnly.FromDateTime(DateTime.Now)}] {message}.");
    }
}