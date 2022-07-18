using System;

namespace Helpers
{
    public class Lesson4Task
    {
        //1. Find the minimum element of an array
        public static int getMinimalElement(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int arrayMin = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < arrayMin)
                {
                    arrayMin = array[i];
                }
            }

            return arrayMin;
        }

        //2. Find the maximum element of an array
        public static int getMaximumElement(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int arrayMax = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > arrayMax)
                {
                    arrayMax = array[i];
                }
            }

            return arrayMax;
        }

        //3. Find the index of the minimum element of the array
        public static int getMinimalElementIndex(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int arrayMin = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < arrayMin)
                {
                    arrayMin = i;
                }
            }

            return arrayMin;
        }

        //4. Find the index of the maximum element of the array
        public static int getMaximalElementIndex(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int arrayMaxIndex = 0;
            int arrayMax = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > arrayMax)
                {
                    arrayMaxIndex = i;
                }
            }

            return arrayMaxIndex;
        }

        //5. Calculate the sum of array elements with odd indices
        public static int getSumElementsByOddIndices(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int summ = 0;

            for (int i = 1; i < array.Length; i++)
            {
                i = +1;
                summ += array[i];
            }

            return summ;
        }

        //6. Make an array reverse(an array in the opposite direction)
        //Other solution: Array.Reverse();
        //https://docs.microsoft.com/en-us/dotnet/api/system.array.reverse
        public static int[] ReverseArray(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int lastIndex = array.Length - 1;

            for (int i = 0; i < (array.Length / 2); i++)
            {
                Swap(ref array[i], ref array[lastIndex--]);
            }

            return array;
        }

        //7. Count the number of odd array elements
        public static int GetSumElementsByOddElements(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int summ = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    summ += array[i];
                }
            }

            return summ;
        }

        //8. Swap the first and second half of the array, for example, for an array of 1 2 3 4, the result is 3 4 1 2, or for 1 2 3 4 5 -> 4 5 3 1 2.
        public static int[] SwapHalfArray(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int half = array.Length / 2;
            int offset = array.Length - half;

            for (int i = 0; i < half; i++)
            {
                int temp = array[i];
                array[i] = array[offset + i];
                array[offset + i] = temp;
            }

            return array;
        }

        //9. Sort the array in ascending order in one of the ways: bubble(Bubble), selection(Select) or inserts(Insert))
        //Array.Sort(array);
        public static int[] SortArrrayInAscendingOrder(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            for (int i = 1; i < array.Length; i++)
            {
                int value = array[i];
                int flag = 0;

                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (value < array[j])
                    {
                        array[j + 1] = array[j--];
                        array[j + 1] = value;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return array;
        }


        //10. Sort the array in descending order in one of the ways(different from the method in the 9th task): bubble(Bubble), selection(Select) or inserts(Insert))
        //Array.Sort(array);
        //Array.Reverse(array);
        public static int[] sortArrrayInDescendingOrder(int[] array)
        {
            EmptyArrayExeptionCheck(array);

            int temp;

            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        temp = array[i + 1];

                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }
            }

            return array;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void EmptyArrayExeptionCheck(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Empty array!");
            }
        }
    }
}