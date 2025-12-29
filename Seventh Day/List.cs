using System.Collections;
class List
{
    public static void Lists()
    {
        List<int> numbers = new List<int> { 1, 2, 3 };
        numbers.Add(4);
        numbers.Remove(2);
    Console.Write("List: ");
    foreach (int n in numbers)
    {
        Console.Write(n+" ");
    }
    Console.WriteLine();
    Dictionary<int,string> dict = new Dictionary<int, string>();
    dict.Add(1,"Aryan");
    foreach(KeyValuePair<int,string>kv in dict)
        {
            Console.WriteLine($"{kv.Key} = {kv.Value}");
        }
    SortedList<int, string> list = new SortedList<int, string>();
    list.Add(2, "B");
    list.Add(1, "A");
    foreach(KeyValuePair<int,string>kv in list)
        {
            Console.WriteLine($"{kv.Key} = {kv.Value}");
        }
    Hashtable ht = new Hashtable();
    ht.Add(1, "Admin");
    Console.WriteLine(ht[1]);
    Stack<int> stack = new Stack<int>();
    stack.Push(10);
    stack.Pop();
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(10);
    queue.Dequeue();






            
    }
}