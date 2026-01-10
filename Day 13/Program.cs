using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Xml.Serialization;

// class School
// {
//     public int Good;
//     public int Aryan(int a, int b)
//     {
//         return a + b;
//     }
// }
delegate void PaymentDelegate(decimal amount);
class PaymentServices
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Processing Payment: "+amount);
    }
    public void RTGS(decimal amount)
    {
        Console.WriteLine("Rtgs Amount: "+amount);
    }
}
static class PaymentExtension
{
    public static bool IsValidPayment(this decimal amount)
    {
        return amount>0&&amount<=10_00_000;
    }
}
delegate void ErrorDelegate(string message);
class Button{
    
    public delegate void ClickHandler();
    public event ClickHandler Clicked;
    public void Click()
    {
        Clicked?.Invoke();
    }
}
class Downloader
{
    public delegate void DownloadDelegate();
    public event DownloadDelegate DownloadCompleted;
    public void CompleteDownload()
    {
        DownloadCompleted?.Invoke();
    }
}
public class User
{
    public int Id{get;set;}
    public string Name{get;set;}
}
class Program
{
    static void Main()
    {
        // School Student1=new School();
        // int g=Student1.Aryan(7,8);
        // Console.WriteLine(g);
        PaymentServices service = new PaymentServices();
        PaymentDelegate payment = service.ProcessPayment;
        // payment(5000);
        decimal amount=5000;
        if(amount.IsValidPayment())payment(amount);
        else Console.WriteLine("Bbye");
        PaymentDelegate Done=null;
        Done+= service.ProcessPayment;
        Done+= service.RTGS;
        Done(amount);
        Action<string> logActivity=message=>Console.WriteLine("Log Entry: "+message);
        DateTime time=DateTime.Now;
        logActivity("User logged in at "+time);
        Func<decimal,decimal,decimal> calculateDiscount=(price,discount)=>price - (price*discount/100);
        Console.WriteLine(calculateDiscount(1000,10));
        Predicate<int> isEligible=age=>age>=18;
        Console.WriteLine(isEligible(20));
        ErrorDelegate errorHandler=delegate(string msg)
        {
            Console.WriteLine("Error: "+msg);
        };
        errorHandler("File not Found");
        Button btn = new Button();
        btn.Clicked+=()=>Console.WriteLine("Button was clicked");
        btn.Clicked+=()=>Console.WriteLine("Lets go");
        btn.Clicked+=()=>logActivity("User logged in at "+time);
        btn.Click();
        Downloader d = new Downloader();
        d.DownloadCompleted+=()=>Console.WriteLine("Download Compleated.");
        d.CompleteDownload();
        
        FileInfo file=new FileInfo("sample.txt");
        if (!file.Exists)
        {
            using(StreamWriter writer = file.CreateText())
            {
                writer.WriteLine("Hello FileInfo class");
            }
        }

        Console.WriteLine("File Name: " + file.Name);
        Console.WriteLine("File Size: " + file.Length + " bytes");
        Console.WriteLine("Created On: " + file.CreationTime);
        Directory.CreateDirectory("Logs");
        if (Directory.Exists("Logs"))
        {
            Console.WriteLine("Logs directory created successfully.");
        }
        DirectoryInfo dir=new DirectoryInfo("Logs");
        if(!dir.Exists){dir.Create();}
        Console.WriteLine("Directory Name: "+dir.Name);
        Console.WriteLine("Created on: "+dir.CreationTime);
        Console.WriteLine("Full Path: "+dir.FullName);

        User user=new User{Id=1,Name="Aryan"};
        // User user1=new User{Id=2,Name="Mango"};
        // string json=JsonSerializer.Serialize(user);
        // File.AppendAllText("user.json",json);
        // Console.WriteLine("User serialized successfully.");  
        string json = File.ReadAllText("user.json");
        User user = JsonSerializer.Deserialize<User>(json);
        Console.WriteLine($"User Loaded: {user.Id},{user.Name}");
        XmlSerializer serializer=new XmlSerializer(typeof(User));
        using(FileStream fs=new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs,user);
        }
        Console.WriteLine("XML Serialized");
        Console.WriteLine(typeof(User));    
        


        


    }
}