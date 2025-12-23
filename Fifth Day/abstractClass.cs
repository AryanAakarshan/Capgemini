using System;
abstract class Animal
{
    public abstract void Soundy();
    public void Sleep()
    {
        Console.WriteLine("Animal is sleeping");
    }
}
class Dog : Animal
{
    public override void Soundy()
    {
        Console.WriteLine("Dog barks");
    }
}

interface IAnimal
{
    void Sound();   // no body
    int Numbers(int num);
}

class Sheep : IAnimal
{
    public void Sound()
    {
        Console.WriteLine("Dog barks");
    }
    public int Numbers(int num)
    {
        Console.WriteLine("Number of sheeps: "+ num);
        return num;
    }
}
interface ILogger
{
    void Log();
}
interface INotifier
{
    void Log();
}
class FileLogger : ILogger, INotifier
{
    void ILogger.Log()
    {
        Console.WriteLine("Logging to file via ILogger");
    }
    void INotifier.Log()
    {
        Console.WriteLine("Logging to notification via INotifier");
    }
}