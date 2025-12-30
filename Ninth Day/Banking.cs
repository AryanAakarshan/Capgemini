namespace BankingSystem
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message)
            : base(message)
        {
        }
    }
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        private const string LogFilePath = "BankErrorLog.txt";
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be null or empty.");

            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        public void Withdraw(decimal amount)
        {
            try
            {
                if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be greater than zero.");

                if (amount > Balance)
                    throw new InsufficientBalanceException(
                        $"Withdrawal failed. Available balance: {Balance}"
                    );

                Balance -= amount;
                Console.WriteLine($"Withdrawal successful. Updated balance: {Balance}");
            }
            catch (InsufficientBalanceException ex)
            {
                LogException(ex);
                throw; // Preserve business exception
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw new BankOperationException(
                    "An unexpected banking error occurred during withdrawal.",
                    ex
                );
            }
        }
        private void LogException(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine($"{DateTime.now} | {AccountNumber} | {ex.ToString()} {Environment.NewLine}");
                writer.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            BankAccount account = new BankAccount("ACC123", 1000);
            account.Withdraw(1500); // Exceeds balance
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Insufficient Balance Error:");
            Console.WriteLine(ex.Message);
        }
        catch (BankOperationException ex)
        {
            Console.WriteLine("Bank Operation Error:");
            Console.WriteLine(ex.Message);

            if (ex.InnerException != null)
            {
                Console.WriteLine("Root Cause:");
                Console.WriteLine(ex.InnerException.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Application Error:");
            Console.WriteLine(ex.Message);
        }
    }
}
