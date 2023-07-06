using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Challenge 1: Array Max Result
            int[] numbers = ReadNumbersFromUser(5, 1, 10);
            Console.WriteLine("Array: " + string.Join(", ", numbers));
            int selectedNumber = ReadNumberFromUser("Select a number: ", 1, 10);
            int score = CalculateScore(numbers, selectedNumber);
            Console.WriteLine("Score: " + score);

            // Challenge 2: Leap Year Calculator
            int year = ReadNumberFromUser("Enter a year: ");
            bool isLeapYear = IsLeapYear(year);
            Console.WriteLine("Is leap year? " + isLeapYear);

            // Challenge 3: Perfect Sequence
            int[] sequence = ReadNumbersFromUser();
            string isPerfectSequence = IsPerfectSequence(sequence) ? "Yes" : "No";
            Console.WriteLine("Is perfect sequence? " + isPerfectSequence);

            // Challenge 4: Sum of Rows
            int[,] matrix = ReadMatrixFromUser();
            int[] rowSums = CalculateRowSums(matrix);
            Console.WriteLine("Row sums: " + string.Join(", ", rowSums));
        }

        static int[] ReadNumbersFromUser(int count, int minValue, int maxValue)
        {
            int[] numbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                numbers[i] = ReadNumberFromUser($"Enter number {i + 1}: ", minValue, maxValue);
            }
            return numbers;
        }

        static int[] ReadNumbersFromUser()
        {
            Console.Write("Enter the length of the sequence: ");
            int length = int.Parse(Console.ReadLine());
            int[] sequence = new int[length];
            for (int i = 0; i < length; i++)
            {
                sequence[i] = ReadNumberFromUser($"Enter number {i + 1}: ");
            }
            return sequence;
        }

        static int ReadNumberFromUser(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int number;
            bool isValidInput;
            do
            {
                Console.Write(message);
                isValidInput = int.TryParse(Console.ReadLine(), out number)
                    && number >= minValue && number <= maxValue;
                if (!isValidInput)
                {
                    Console.WriteLine($"Invalid input. Enter a number between {minValue} and {maxValue}.");
                }
            } while (!isValidInput);
            return number;
        }

        static int[,] ReadMatrixFromUser()
        {
            int rowCount = ReadNumberFromUser("Enter the number of rows: ");
            int colCount = ReadNumberFromUser("Enter the number of columns: ");
            int[,] matrix = new int[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = ReadNumberFromUser($"Enter the element at position ({i + 1},{j + 1}): ");
                }
            }
            return matrix;
        }

        static int CalculateScore(int[] numbers, int selectedNumber)
        {
            int score = 0;
            foreach (int number in numbers)
            {
                if (number == selectedNumber)
                {
                    score += number;
                }
            }
            return score;
        }

        static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        static bool IsPerfectSequence(int[] sequence)
        {
            int product = 1;
            int sum = 0;
            foreach (int number in sequence)
            {
                if (number < 0)
                {
                    return false; // Negative numbers are not valid in a perfect sequence
                }
                product *= number;
                sum += number;
            }
            return product == sum;
        }

        static int[] CalculateRowSums(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);
            int[] rowSums = new int[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                int sum = 0;
                for (int j = 0; j < colCount; j++)
                {
                    sum += matrix[i, j];
                }
                rowSums[i] = sum;
            }
            return rowSums;
        }
    }
}
