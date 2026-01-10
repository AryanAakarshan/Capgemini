// using System;

// class Chocolate
// {
//     public string Flavour { get; set; }
//     public int Quantity { get; set; }
//     public int PricePerUnit { get; set; }

//     // Check flavour
//     public bool flavourCheck()
//     {
//         if (Flavour == "Dark" || Flavour == "Milk" || Flavour == "White")
//             return true;

//         return false;
//     }

//     // Calculate discount amount
//     public decimal DiscountedPrice(decimal amount)
//     {
//         if (Flavour == "Dark")
//             return (amount * 18) / 100;
//         else if (Flavour == "Milk")
//             return (amount * 12) / 100;
//         else if (Flavour == "White")
//             return (amount * 6) / 100;

//         return 0;
//     }

//     // Final price after discount
//     public decimal CalculateDiscountedPrice(decimal amount)
//     {
//         decimal discount = DiscountedPrice(amount);
//         return amount - discount;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Chocolate chocolate = new Chocolate();

//         Console.Write("Enter Flavour: ");
//         chocolate.Flavour = Console.ReadLine();

//         Console.Write("Enter Quantity: ");
//         chocolate.Quantity = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter Price per unit: ");
//         chocolate.PricePerUnit = Convert.ToInt32(Console.ReadLine());

//         if (!chocolate.flavourCheck())
//         {
//             Console.WriteLine("Invalid flavour");
//             return;
//         }

//         decimal totalAmount = chocolate.PricePerUnit * chocolate.Quantity;
//         decimal finalPrice = chocolate.CalculateDiscountedPrice(totalAmount);
//         Console.WriteLine("Total price: "+totalAmount);
//         Console.WriteLine("Final Price after discount: " + finalPrice);
//     }
// }
