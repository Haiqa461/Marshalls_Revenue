# Marshalls Revenue Calculator

## Overview

Marshalls Revenue Calculator is a console application written in C# that calculates and displays the expected revenue from interior and exterior mural projects. The application prompts the user to input the number of murals and the month of the year, and then calculates the revenue based on the provided information.

## Features

- Prompts the user to enter the number of interior and exterior murals (0-30).
- Prompts the user to enter the month number (1-12).
- Calculates the revenue based on the number of murals and the month.
- Displays a detailed revenue summary.
- Provides a comparison of the number of interior and exterior murals scheduled.

## Usage

### Input

1. **Number of Murals**: The user is prompted to enter the number of interior and exterior murals. The input must be an integer between 0 and 30.
2. **Month Number**: The user is prompted to enter the month number. The input must be an integer between 1 and 12.

### Output

The application will display:
- The number of interior murals.
- The cost per interior mural.
- The subtotal for interior murals.
- The number of exterior murals.
- The cost per exterior mural.
- The subtotal for exterior murals.
- The total expected revenue.
- A comparison message indicating whether more interior or exterior murals are scheduled.

## Revenue Calculation

- **Interior Murals**:
  - The cost per interior mural is $450 in July (7) and August (8).
  - The cost per interior mural is $500 for all other months.

- **Exterior Murals**:
  - No exterior murals are scheduled in December (12), January (1), and February (2).
  - The cost per exterior mural is $699 in April (4), May (5), September (9), and October (10).
  - The cost per exterior mural is $750 for all other eligible months.

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/marshalls-revenue-calculator.git
   ```
2. Navigate to the project directory:
   ```bash
   cd marshalls-revenue-calculator
   ```
3. Open the project in your preferred C# IDE (e.g., Visual Studio).
4. Build and run the project.

## Code

```csharp
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
```

## License

This project is licensed under the MIT License. See the LICENSE file for details.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## Author

- Haiqa Qaiser 

