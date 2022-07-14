using System;

namespace Helpers
{
    public class Lesson2Task
    {
        //1.	The user enters 2 numbers (A and B). If A > B, result is A+B, if A=B, result is A * B, if A < B, result is A-B.
        static int First(int a, int b)
        {
            if (a > b)
            {
                return a + b;
            }
            else if (a == b)
            {
                return a * b;
            }
            else
            {
                return a - b;
            }
        }

        //2.	The user enters 2 numbers (X and Y). Determine which quarter the point with coordinates (X, Y) belongs to.
        static int GetCoordinateQuater(int x, int y)
        {
            int result = 0;
            if (x > 0 && y > 0)
            {
                result = 1;
            }
            else if (x > 0 && y < 0)
            {
                result = 2;
            }
            else if (x < 0 && y < 0)
            {
                result = 3;
            }
            else if (x < 0 && y > 0)
            {
                result = 4;
            }

            return result;
        }

        //3. The user enters 3 numbers (A, B and C). Print them to the console in ascending order.
        static (int min, int medium, int high) GetAscendingOrder(int a, int b, int c)
        {
            if (a == b || a == c || b == c)
            {
                throw new ArgumentException("Please enter a different numbers!");
            }

            if (a >= b && b >= c)
            {
                return (c, b, a);
            }
            else if (a >= c && c >= b)
            {
                return (b, c, a);
            }
            else if (b >= a && b >= c && a >= c)
            {
                return (c, a, b);
            }
            else if (b >= c && c >= a)
            {
                return (a, c, b);
            }
            else if (c >= a && a >= b)
            {
                return (b, a, c);
            }
            else if (c >= b && b >= a)
            {
                return (a, b, c);
            }
            return (0, 0, 0);
        }

        //4. The user enters 3 numbers(A, B and C). Print to the console the solution(X-values) of the standard form quadratic equation, where AX^2+BX+C=0.
        static (double x1, double x2) GetRootsOfQuadraticEquation(int a, int b, int c)
        {
            double discriminant = b * b - 4 * a * c;
            double x1 = 0;
            double x2 = 0;

            if (discriminant > 0)
            {
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            }
            else if (discriminant == 0)
            {
                x1 = -b / 2 * a;
                x2 = x1;
            }
            else
            {
                x1 = x2;
            }

            return (x1, x2);
        }

        //5. The user enters a two-digit number.Print the capitalization of this number to the console. For example, typing "25" will print "twenty-five" to the console.
        static string PrintNumberCapitalization(int userInput)
        {
            if (userInput < 10 || userInput > 99 || userInput < -99 || userInput > -10)
            {
                throw new ArgumentException("Please enter a two-digit number!");
            }

            int firstNumber = userInput / 10;
            int secondNumber = userInput % 10;

            string firstNumberName = null;
            string secondNumberName = null;
            string result = null;

            if (userInput >= 20 || userInput <= 10)
            {
                switch (firstNumber)
                {
                    case 2:
                        firstNumberName = "Twenty";
                        break;
                    case 3:
                        firstNumberName = "Thirty";
                        break;
                    case 4:
                        firstNumberName = "Fourty";
                        break;
                    case 5:
                        firstNumberName = "Fifty";
                        break;
                    case 6:
                        firstNumberName = "Sixty";
                        break;
                    case 7:
                        firstNumberName = "Seventy";
                        break;
                    case 8:
                        firstNumberName = "Eighty";
                        break;
                    case 9:
                        firstNumberName = "Ninety";
                        break;
                }
                switch (secondNumber)
                {
                    case 1:
                        secondNumberName = "One";
                        break;
                    case 2:
                        secondNumberName = "Two";
                        break;
                    case 3:
                        secondNumberName = "Three";
                        break;
                    case 4:
                        secondNumberName = "Four";
                        break;
                    case 5:
                        secondNumberName = "Five";
                        break;
                    case 6:
                        secondNumberName = "Six";
                        break;
                    case 7:
                        secondNumberName = "Seven";
                        break;
                    case 8:
                        secondNumberName = "Eight";
                        break;
                    case 9:
                        secondNumberName = "Nine";
                        break;
                }
                result = (firstNumberName + " " + secondNumberName).Trim();
            }
            else if (userInput >= 10 && userInput < 20)
            {
                switch (userInput)
                {
                    case 10:
                        result = "Ten";
                        break;
                    case 11:
                        result = "Eleven";
                        break;
                    case 12:
                        result = "Twelve";
                        break;
                    case 13:
                        result = "Thirteen";
                        break;
                    case 14:
                        result = "Fourteen";
                        break;
                    case 15:
                        result = "Fifteen";
                        break;
                    case 16:
                        result = "Sixteen";
                        break;
                    case 17:
                        result = "Seventeen";
                        break;
                    case 18:
                        result = "Eighteen";
                        break;
                    case 19:
                        result = "Nineteen";
                        break;
                }
                result += result;
            }
            return result;
        }
    }
}

