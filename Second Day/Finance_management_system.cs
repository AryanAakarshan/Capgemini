using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
class Finance_Management
{
    public static void Finance_Management_System()
    {
        int count=0;
        int balance =0;
        bool flag = true;
        int withdrawn=0;
        int total_money_spend=0;
        while(flag)
        {
            if(count==0){
            Console.Write("Balance: ");
            balance=Convert.ToInt32(Console.ReadLine());}count++;
            Console.WriteLine("1.Debit");
            Console.WriteLine("2.Credit");
            Console.WriteLine("3.Exit");
            Console.Write("Choose: ");
            int input=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            switch (input)
            {
                case 1 :
                    {
                        Console.Write("1.ATM Withdrawal Limit Validation\n2.EMI Burden Evaluation\n3.Transaction-Based Daily Spending Calculator\n4.Minimum Balance Compliance Check\n5.Main manu\nchoose: ");

                        int input1=Convert.ToInt32(Console.ReadLine());
                        switch (input1)
                        {
                            case 1:
                            Console.Write("Enter Amount to be withdrawn: ");
                            int b=Convert.ToInt32(Console.ReadLine());
                            if(withdrawn<=40000){
                                balance -=b;
                                Console.WriteLine($"Balace: {balance}");
                                withdrawn+=b;
                                break;
                                }
                            else
                                {
                                    Console.WriteLine("Withdrawl limit reached");
                                    break;
                                }
                            case 2:
                            Console.Write("Enter Monthly Income: ");
                            int a=Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nEnter EMI Amount: ");
                            int e=Convert.ToInt32(Console.ReadLine());
                            int l=(a/100)*40;
                                if (l > e)
                                {
                                    Console.WriteLine("EMI exceeds safe income limit.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("EMI is financially manageable");
                                    break;
                                }

                            case 3:
                                {
                                    Console.Write("Enter Number of Transition: ");
                                    int k=Convert.ToInt32(Console.ReadLine());
                                    for(int i = 0; i < k; i++)
                                    {
                                        Console.Write("\nEnter Amount: ");
                                        int temp=Convert.ToInt32(Console.ReadLine());
                                        total_money_spend+=temp;
                                    }
                                    Console.WriteLine($"\nTotal Money Spend={total_money_spend}");
                                    break;

                                }
                            case 4:
                                {
                                    if (balance < 20000)
                                    {
                                        Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Minimum balance requirement satisfied.");
                                    }
                                    break;
                                }
                                default:
                                {
                                    break;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("1. Net Salary Credit Calculation\n2.Fixed Deposit Maturity Calculation\n3.Credit Card Reward Points Evaluation\n4.Employee Bonus Eligibility Check\n5.Main menu\nChoose:");
                        int input1=Convert.ToInt32(Console.ReadLine());
                        switch (input1)
                        {
                            case 1:
                                {
                                    Console.Write("Enter gross salery: ");
                                    int f=Convert.ToInt32(Console.ReadLine());
                                    int temp=f/10;
                                    f-=temp;
                                    Console.WriteLine($"Net salary credited: ₹{f}");
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Enter Principle: ");
                                    int p=Convert.ToInt32(Console.ReadLine());
                                    Console.Write("\nEnter Rate: ");
                                    int r=Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Time: ");
                                    int t=Convert.ToInt32(Console.ReadLine());
                                    int intrest=p*r*t/100;
                                    Console.WriteLine($"Fixed Deposit maturity amount: {intrest+p}");
                                    break;
                                }
                            case 3:
                                {
                                    Console.Write("Enter total credit card spending: ");
                                    int s=Convert.ToInt32(Console.ReadLine());
                                    int reward =s/100;
                                    Console.WriteLine($"\nReward points earned: {reward}");
                                    break;
                                }
                            case 4:
                                {
                                    Console.Write("Enter salary: ");
                                    int s = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("\nEnter years of experience: ");
                                    int y = Convert.ToInt32(Console.ReadLine());
                                    if (s >= 500000 && y >= 3)
                                    {
                                        Console.WriteLine("Employee is eligible for bonus.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee is not eligible for bonus.");
                                        break;
                                    }
                                }
                                default:
                                break;
                        }break;
                    }
            case 3:{
                flag=false;
                break;
            }
            default:{
                Console.WriteLine("Please Enter Valid Number");
                break;
            }


            }
        }
    }
}