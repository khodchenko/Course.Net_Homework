using System;

namespace Helpers
{
    public class Lesson3Task
    {
        //1. The user enters 2 numbers(A and B). Raise the number A to the power of B.
        static int RaiseToThePower(int number, int raise)
        {
            if (number > int.MaxValue)
            {
                throw new ArgumentException("Out of int range!");
            }

            int sum = number;
            for (int i = 1; i < raise; i++)
            {
                sum *= number;
            }
            return sum;
        }

        //2. The user enters 1 number(A). Print all numbers from 1 to 1000 that are divisible by A.
        static int GetLessSquareFromA(int number)
        {

            int result = default;

            for (int i = 1; i <= number; i++)
            {
                int numberSquare = i;
                numberSquare *= numberSquare;

                if (numberSquare < number)
                {
                    result++;
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        //3. The user enters 1 number(A). Find the number of positive integers whose square is less than A.
        static int FindTheNumberOfPositiveIntegersWhoseSquareIsLessThanA(int number)
        {
            int result = default;

            for (int i = 1; i * i < number; i++)
            {
                result++;
            }

            return result;
        }

        //4. The user enters 1 number(A). Print the largest divisor(other than A itself) of the number A.
        static int GetLargestDivisorOfA(int number)
        {
            int result = default;

            for (int i = number / 2; i > 1; i--)
            {
                if (number % 1 == 0)
                {
                    result += i;
                    break;
                }
            }

            return result;
        }

        //5. The user enters 2 numbers (A and B). Print the sum of all numbers from the range A to B that are divisible by 7 without a remainder. (Note that B may be less than A if you type).
        static int GetSummOfRangeDivisibleBySeven(int a, int b)
        {
            if(b >= a)
            {
                throw new ArgumentException("B must be less than A!");
            }

            int result = default;

            if (b > a)
            {
                for (; a < b; b--)
                {
                    if (b % 7 == 0)
                    {
                        result += b;
                    }
                }
            }
            return result;
        }

        //6. The user enters 1 number(N). Print the Nth number of the fibonacci series.In the fibonacci series, each next number is the sum of the previous two. The first and second are considered equal to 1.
        static int GetElementOfFibboSeries(int number)
        {
            int a = default;
            int b = 1;
            int result = default;
            for (int i = 2; i < number; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }
            return result;
        }

        //7. The user enters 2 numbers.Find their greatest common divisor using Euclid's algorithm.
        static int GetGreatestDivisiorByEuclid(int a, int b)
        {
            while ((a != 0) && (b != 0))
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return Math.Max(a, b);
        }

        //8. The user enters a positive integer that is the cube of the integer N.Find the number N using binary search algorithm.
        static int FindTheNumberUsingBinarySearchAlgorithm(int a)
        {
            int result = 0;

            for (int i = 0; i <= a; i++)
            {
                if (i * i * i == a)
                {
                    result = i;
                }
            }

            return result;
        }

        //9. The user enters number. Find the number of odd digits of this number.
        static int FindTheNumberOfOddDigitsInThisNumber(int number)
        {
            if (number == 0)
            {
                throw new ArgumentException("Number must be not null!");
            }

            int result = 0;

            for (int i = 0; i <= number; i++)
            {
                if (i % 2 != 0)
                {
                    result++;
                }
            }

            return result;
        }


        //10. The user enters number. Find a number that is a mirror image of the sequence of digits of a given number, for example, given the number 123, output 321.
        static string MirrorNumber(int number)
        {
            string result = string.Empty;
            int digit = 0;

            while (number >= 1)
            {
                digit = number % 10;
                number = number / 10;
                result += digit.ToString();
            }
            return result;
        }

        //11. The user enters a positive integer (N). Print numbers in the range from 1 to N, the sum of whose even digits is greater than the sum of the odd ones.

        //12. The user enters 2 numbers.Tell me if there are the same digits in the spelling of two numbers.For example, for a pair of 123 and 3456789, the answer would be “YES”, and for a pair of 500 and 99, “NO”.
        static string CheckRepeatedDigits(int a, int b)
        {
            string checking = "NO";
            char[] arrayA = a.ToString().ToCharArray();
            char[] arrayB = b.ToString().ToCharArray();

            for (int i = 0; i < arrayA.Length; i++)
            {
                for (int j = 0; j < arrayB.Length; j++)
                {
                    if (arrayA[i] == arrayB[j])
                    {
                        checking = "YES";
                    }
                }
            }

            return checking;
        }
    }
}

