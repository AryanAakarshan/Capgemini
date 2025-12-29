class Repository<T> where T : class
{
    public T Data;
}
class Customber
{
    public string Name;
}
class Calculator
{
    public T Calculate<T>(T a,T b)
    {
        return a;
    }
}
class Printer
{
    public static void Print<T>(T data)
    {
        Console.WriteLine(data);
    }
}