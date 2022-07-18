namespace Helpers
{
    public class Lesson1Task
    {
        //1. The user enters the number of hours, output the number of minutes in that number of hours.
        static int HoursToMinutes(int hours)
        {
            return hours * 60;
        }

        //2. The user enters 2 numbers (A and B). Print the solution to the console.
        static double CalculateSolution(int a, int b)
        {
            return (5 * a + b * b) / (b - a);
        }

        //3. The user enters 2 string values ​​(A and B). Swap the contents of variables A and B.
        static (int a, int b) Swap(int a, int b)
        {
            return (b, a);
        }

        //4. The user enters 2 numbers (A and B). Print to the console the result of dividing A by B and the division remainder.
        static (float result, float divisionRemainder) SomeCalculation(int a, int b)
        {
            float result = a / b;
            float divisionRemainder = a % b;

            return (result, divisionRemainder);
        }

        //5. The user enters 3 non-zero numbers(A, B and C). Print to the console the solution(X value) of the standard linear equation, where A*X+B=C.
        static float LinearEquation(int a, int b, int c)
        {
            return (float)(c - b) / a;
        }

        //6. The user enters 4 numbers(X1, Y1, X2, Y2) describing the coordinates of 2 points on the coordinate plane.Output the equation of a straight line in the format Y=AX+B passing through these points.
        static (double a, double b) EquationOfLine(int x1, int y1, int x2, int y2)
        {
            double a = (y1 - y2) / (x1 - x2);
            double b = y2 - a * x2;

            return (a, b);
        }

        //7. The variable N stores a natural two-digit number(10-99). Write a program that calculates and displays the sum of the digits of n.
        static int SumOfDigits(int someNumber)
        {
            return (someNumber % 10) + (someNumber / 10);
        }
    }
}

