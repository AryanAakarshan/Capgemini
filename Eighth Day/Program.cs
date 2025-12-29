
using System.Diagnostics;

class PatientBill
{
    public string? BillId{get;set;}
    public string PatientName{get;set;}
    public bool HasInsurance{get;set;}
    public  double  ConsultationFee {get;set;}
    public double MedicineCharges{get;set;}
    public double GrossAmount{get;set;}
    public double DiscountAmount{get;set;}
    public double FinalPayable{get;set;}

}

class Program
{
    static PatientBill? lastBill = null;
    public static void Main()
    {
        bool flag=true;
        while(flag){

            Console.WriteLine("\n1. Create New Bill");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            int choose=Convert.ToInt32(Console.ReadLine());
        
        switch(choose){
            
            case 1:
            CreateNewBill();
            break;
            case 2:
            ViewLastBill();
            break;
            case 3:
            ClearLastBill();
            break;
            case 4:
            flag=false;
            break;
            default:
            break;
        }
        }
        
    }
    static void CreateNewBill()
    {
        PatientBill bill = new PatientBill();
        Console.Write("Enter BillNo. : ");
        string? billId = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(billId))
        {
            Console.WriteLine("Bill ID cannot be null or empty.");
            return;
        }
        bill.BillId = billId;
        Console.Write("\nEnter Patient Name: ");
        bill.PatientName = Console.ReadLine() ?? "Unknown";

        Console.Write("Has Insurance (Y/N): ");
        char fo;
        fo=Convert.ToChar(Console.ReadLine());
        if(fo=='Y'||fo=='y'){
        bill.HasInsurance =true;}
        else
        {
            bill.HasInsurance=false;
        }

        Console.Write("Enter Consultation Fee: ");
        bill.ConsultationFee = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Medicine Charges: ");
        bill.MedicineCharges = Convert.ToDouble(Console.ReadLine());

        bill.GrossAmount = bill.ConsultationFee + bill.MedicineCharges;
        Console.Write("Enter Discount Amount: ");
        bill.DiscountAmount = Convert.ToDouble(Console.ReadLine());
        bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;

        lastBill = bill;

        Console.WriteLine("Bill created successfully.");
    }
    static void ViewLastBill()
    {
        if (lastBill == null)
        {
            Console.WriteLine("No bill available.");
            return;
        }
        Console.WriteLine("\n--- Last Patient Bill ---");
        Console.WriteLine($"Bill ID: {lastBill.BillId}");
        Console.WriteLine($"Patient Name: {lastBill.PatientName}");
        Console.WriteLine($"Has Insurance: {lastBill.HasInsurance}");
        Console.WriteLine($"Consultation Fee: {lastBill.ConsultationFee}");
        Console.WriteLine($"Medicine Charges: {lastBill.MedicineCharges}");
        Console.WriteLine($"Gross Amount: {lastBill.GrossAmount}");
        Console.WriteLine($"Discount: {lastBill.DiscountAmount}");
        Console.WriteLine($"Final Payable: {lastBill.FinalPayable}");


    }
    static void ClearLastBill()
    {
        lastBill = null;
        Console.WriteLine("Last bill cleared.");
    }
}