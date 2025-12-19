using System;
using System.Collections;
class Finance_Control
{
    public static void Finance_Control_System()
    {
        int count=0;
        int balance=0;
        bool flag = true;
        while(flag)
        {
            Console.WriteLine("1.Check Loan Eligibility");
            Console.WriteLine("2.Calculate Tax");
            Console.WriteLine("3.Enter Transactions");
            Console.WriteLine("4.Exit");
            Console.Write("Choose: ");
            int input=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            switch (input)
            {
                case 1 :
                {
                    Console.Write("Enter your age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nEnter your monthly income: ");
                    int income = Convert.ToInt32(Console.ReadLine());
                    if(age>=21 && income >= 30000)
                {
                    Console.WriteLine("You are Eligible bro.");
                }
                else
                {
                    Console.WriteLine("You are not eligible bro");
                }
                break;
                }
                case 2 :{
                    Console.Write("Enter Your Anual Income: ");
                    int AIncome=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                if (AIncome <= 250000)
                {

                    Console.WriteLine("Your Income Tax rate is 0%\n");
                }
                else if(AIncome<=500000 && AIncome > 250000)
                {
                    int tax=(AIncome/100)*5;
                    Console.WriteLine($"Your Income Tax rate is 5% = {tax}\n");
                }else if(AIncome<=1000000 && AIncome > 500000)
                {
                    int tax=(AIncome/100)*20;
                    Console.WriteLine($"Your Income Tax rate is 20% = {tax}\n");
                }else if(AIncome > 1000000)
                {   
                    int tax=(AIncome/100)*30;
                    Console.WriteLine($"Your Income Tax rate is 30% ={tax}\n");
                }break;
                
            }
            case 3 :{
                if (count == 0)
                {
                    Console.Write("Enter Current Balance: ");
                    balance=Convert.ToInt32(Console.ReadLine());
                }
                count++;
                if (count > 4)
                {
                    Console.WriteLine("You have exceeded transition limit.\n");
                    break;
                }
                Console.Write("\n1.Deposit\n2.Withdrawl\n");
                Console.Write("Choose: ");
                int a=Convert.ToInt32(Console.ReadLine());
                if (a == 1)
                {
                    Console.Write("Enter Amount : ");
                    int b=Convert.ToInt32(Console.ReadLine());
                    balance=balance+b;
                }
                else if(a==2)
                {
                    Console.Write("Enter Amount: ");
                    int b=Convert.ToInt32(Console.ReadLine());
                    balance=balance-b;
                }
                else
                        {
                            Console.WriteLine("Invalid Input.");            
                        }
                        Console.WriteLine($"Balance:{balance}");
                        break;
            }

            case 4:{
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