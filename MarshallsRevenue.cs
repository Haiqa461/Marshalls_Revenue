using System;

namespace MarshallsRevenue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Marshalls Revenue Calculator");

            // Prompting user for number of interior and exterior murals
            int interiorMurals = GetNumberOfMurals("interior");
            int exteriorMurals = GetNumberOfMurals("exterior");

            // Prompting user for month number
            int monthNumber = GetMonthNumber();

            // Calculate revenue for interior and exterior murals
            double interiorRevenue = CalculateInteriorRevenue(interiorMurals, monthNumber);
            double exteriorRevenue = CalculateExteriorRevenue(exteriorMurals, monthNumber);

            // Displaying results
            Console.WriteLine("\nRevenue Summary:");
            Console.WriteLine($"Number of Interior Murals: {interiorMurals}");
            Console.WriteLine($"Cost per Interior Mural: ${interiorRevenue / interiorMurals}");
            Console.WriteLine($"Subtotal for Interior Murals: ${interiorRevenue}");
            Console.WriteLine($"Number of Exterior Murals: {exteriorMurals}");
            Console.WriteLine($"Cost per Exterior Mural: ${exteriorRevenue / exteriorMurals}");
            Console.WriteLine($"Subtotal for Exterior Murals: ${exteriorRevenue}");
            Console.WriteLine($"Total Expected Revenue: ${interiorRevenue + exteriorRevenue}");

            // Check if more interior murals are scheduled than exterior ones
            if (interiorMurals > exteriorMurals)
                Console.WriteLine("More interior murals are scheduled than exterior ones.");
            else if (interiorMurals < exteriorMurals)
                Console.WriteLine("More exterior murals are scheduled than interior ones.");
            else
                Console.WriteLine("Equal number of interior and exterior murals are scheduled.");

            Console.ReadLine();
        }

        static int GetNumberOfMurals(string muralType)
        {
            int numberOfMurals;
            do
            {
                Console.Write($"Enter number of {muralType} murals (0-30): ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfMurals) || numberOfMurals < 0 || numberOfMurals > 30);

            return numberOfMurals;
        }

        static int GetMonthNumber()
        {
            int monthNumber;
            do
            {
                Console.Write("Enter the month number (1-12): ");
            } while (!int.TryParse(Console.ReadLine(), out monthNumber) || monthNumber < 1 || monthNumber > 12);

            return monthNumber;
        }

        static double CalculateInteriorRevenue(int numberOfMurals, int monthNumber)
        {
            double interiorMuralPrice = (monthNumber == 7 || monthNumber == 8) ? 450 : 500;
            return numberOfMurals * interiorMuralPrice;
        }

        static double CalculateExteriorRevenue(int numberOfMurals, int monthNumber)
        {
            if (monthNumber >= 12 || monthNumber <= 2)
                return 0;
            else if (monthNumber == 4 || monthNumber == 5 || monthNumber == 9 || monthNumber == 10)
                return numberOfMurals * 699;
            else
                return numberOfMurals * 750;
        }
    }
}
