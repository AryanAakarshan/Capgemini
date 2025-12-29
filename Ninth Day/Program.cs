class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message):base(message){}
}
// class BankAccount
// {
//     public decimal Balance{get;private set;}=5000;
//     public void Withdrawl(decimal Amount)
//     {
//         if (Amount < 0)
//         {
//             throw new ArgumentException("Withdrawl Ampunt is less than 0.");
//         }
//         if (Amount > Balance)
//         {
//             throw new InsufficientBalanceException ("insufficent Balance");
//             Balance-=Amount;
//         }
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         try
//         {
//             Console.Write("Enter Withdrawal amount: ");
//             decimal amount = decimal.Parse(Console.ReadLine());
//             int serviceCharge=100;
//             int devisionCheck=serviceCharge/10;
//             string data = File.ReadAllText("account.txt");
//             BankAccount account = new BankAccount();
//             account.Withdrawl(amount);
//             Console.WriteLine("Withdrawl Successful.");

//         }
//         catch (FormatException ex)
//         {
//             LogException(ex);
//             Console.WriteLine("Invalid input format");
//         }
//         catch (DivideByZeroException ex)
//         {
//             LogException(ex);
//             Console.WriteLine("Arithmetic error occurred.");
//         }
//         catch (FileNotFoundException ex)
//         {
//             LogException(ex);
//             Console.WriteLine("Required File not found.");

//         }
//         catch (InsufficientBalanceException ex)
//         {
//             LogException(ex);
//             Console.WriteLine(ex.Message);
//         }
//         catch (Exception ex)
//         {
//             LogException(ex);
//             Console.WriteLine("An unexpected error occurred.");
//         }
//         finally
//         {
//             Console.WriteLine("Transation attempt Completed.");

//         }
//     FileStream file = null;
//         try
//         {
//         file = new FileStream("data.txt", FileMode.Open);
//         // Perform file operations
//         int data = file.ReadByte();
//         Console.WriteLine(data);
//         }
//     catch (FileNotFoundException ex)
//     {
//         Console.WriteLine("File not found: " + ex.Message);
//     }
//     finally
//     {
//         if (file != null)
//         {
//             file.Close(); // Ensures file is always closed
            
//             Console.WriteLine("File stream closed in finally block.");
//         }
//     }    
// try
// {
//     try
//     {
//         File.ReadAllText("transactions.txt");
//     }
//     catch (IOException ioEx)
//     {
//         throw new ApplicationException(
//             "Unable to load transaction data",
//             ioEx
//         );
//     }
// }
// catch (Exception ex)
// {
//     Console.WriteLine("Message: " + ex.Message);
//     Console.WriteLine("Root Cause: " + ex.InnerException.Message);
// }
//     }
//     static void LogException(Exception ex)
//     {
//         File.AppendAllText(
//             "error.log",DateTime.Now+" | "+ ex.GetType().Name+" | "+ ex.Message+Environment.NewLine
//         );
//     }
// }
public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative", nameof(initialBalance));

        Balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        // Validate numeric range
        if (amount <= 0)
            throw new ArgumentException(
                "Withdrawal amount must be greater than zero",
                nameof(amount));

        // Enforce business rule
        if (amount > Balance)
            throw new InsufficientBalanceException(
                $"Cannot withdraw {amount:C}. Available balance: {Balance:C}");

        Balance -= amount;
    }
}
class Program
{
    static void Main()
    {
        BankAccount bank=new BankAccount(5000);
        bank.Withdraw(10000);
    }
}