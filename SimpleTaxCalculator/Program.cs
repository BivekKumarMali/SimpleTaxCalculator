using System;

namespace SimpleTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Salary");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Your Age");
            int age = Convert.ToInt32(Console.ReadLine());

            TaxCalculator taxCalculator = new TaxCalculator(salary, age);

    
            int totalTax = taxCalculator.CalculateTax();

            Console.WriteLine("Total Tax = " + totalTax);

        }
    }
}
