using System;

namespace Helpers
{
    public class Lesson5Task
    {
        //1. Find the minimum element of an array
        public static int GetMinimalElement(int[,] array)
        {
            CheckArrayForExeption(array);

            int min = array[0, 0];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; i < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }
                }
            }
            return min;
        }

        //2. Find the maximum element of an array
        public static int GetMaximalElement(int[,] array)
        {
            CheckArrayForExeption(array);

            int max = array[0, 0];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; i < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }
            return max;
        }

        //3. Find the index of the minimum element of the array
        public static (int indexA, int indexB) GetMinimalIndex(int[,] array)
        {
            CheckArrayForExeption(array);

            int min = array[0, 0];
            int indexA = 0;
            int indexB = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; i < array.GetLength(1); j++)
                {
                    if (array[i, j] <= min)
                    {
                        indexA = i;
                        indexB = j;
                    }
                }
            }
            return (indexA, indexB);
        }

        //4. Find the index of the maximum element of the array
        public static (int indexA, int indexB) GetMaximalIndex(int[,] array)
        {
            CheckArrayForExeption(array);

            int min = array[0, 0];
            int indexA = 0;
            int indexB = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; i < array.GetLength(1); j++)
                {
                    if (array[i, j] >= min)
                    {
                        indexA = i;
                        indexB = j;
                    }
                }
            }
            return (indexA, indexB);
        }

        //5. Find the number of array elements that are greater than all their neighbors at the same time
        //6. Flip an array about its main diagonal
        public static int[,] FlipArray(int[,] array)
        {
            CheckArrayForExeption(array);

            int[,] flippedArray = new int[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    flippedArray[i, j] = array[j, i];
                }
            }

            return flippedArray;
        }
        private static void CheckArrayForExeption(int[,] array)
        {
            if (array == null || array.GetLength(0) == 0 || array.GetLength(1) == 0)
            {
                throw new ArgumentException("Empty array!");
            }
        }
    }
}
