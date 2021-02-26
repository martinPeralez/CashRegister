using System;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)

        {
            double cost = Convert("Enter purchase amount.");
            double payment = Convert("Enter payment amount.");
            Check(payment, cost);
        }
        static void Check(double payment, double cost)
        {
            while (payment < cost)
            {
                Console.WriteLine("Please give a payment higher than the cost. Let's start over.");
                cost = Convert("Enter purchase amount.");
                payment = Convert("Enter payment amount.");
            }
            double change = Convert(payment, cost);
            //20's
            change = Calculate(change, 20.00, "20's");
            //10's
            change = Calculate(change, 10.00, "10's");
            //5's
            change = Calculate(change, 5.00, "5's");
            //1's
            change = Calculate(change, 1.00, "1's");
            //Quarters
            change = Calculate(change, .25, "Quarters");
            //Dimes
            change = Calculate(change, .10, "Dimes");
            //Nickles
            change = Calculate(change, .05, "Nickles");
            //Pennys
            change = Calculate(change, .01, "Penny");
        }
        static double Convert(string inputString)
        {
            double convertStr = 0.0;
            bool check = true;
            while (check == true)
            {
                try
                {
                    Console.WriteLine(inputString);
                    convertStr = double.Parse(Console.ReadLine());

                    while (convertStr <= 0)
                    {
                        Console.WriteLine($"Please enter a value greater than Zero. {inputString}");
                        convertStr = double.Parse(Console.ReadLine());
                    }

                    check = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Something went wrong. Please try again. { e.Message}");
                }
            }
            return convertStr;
        }
        static double Convert(double payment, double cost)
        {
            double change = payment - cost;
            Console.WriteLine($"Your total change due is {Math.Round(change, 2)}");
            return change;
        }
        static double Calculate(double changeDue, double divMod, string name)
        {
            int result = (int)(changeDue / divMod);

            if (result < 1) { }
            else
            {
                Console.WriteLine($"{name}: {result}");
            }
            return Math.Round(changeDue % divMod, 2);
        }
    }
}
