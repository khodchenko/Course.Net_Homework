using System;
using System.IO;

namespace Helpers
{
    public class Lesson6Task
    {
        //1. Copy text from one file to another.
        public static void CopyTextFromFileToAnotherFile(string path1, string path2)
        {
            if (path1 == null)
            {
                throw new ArgumentException("Empty file 1 path!");
            }

            using (var streamReader = new StreamReader(path1))
            {
                using (var streamWritter = new StreamWriter(path2))
                {
                    while (!streamReader.EndOfStream)
                    {
                        streamWritter.WriteLine(streamReader.ReadLine());
                    }
                }
            }
        }

        //2. Find sum of all numbers in file.
        public static int CopyTextFromFileToAnotherFile(string path)
        {
            if (path == null)
            {
                throw new ArgumentException("Empty file path!");
            }

            string[] stringArray = { };


            using (var streamReader = new StreamReader(path))
            {
                var numbers = streamReader.ReadToEnd();
                stringArray = numbers.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            int[] numbersArray = new int[stringArray.Length];
            int sum = 0;
            foreach (var item in stringArray)
            {
                numbersArray[item.IndexOf(item)] = Convert.ToInt32(item);
                sum += numbersArray[item.IndexOf(item)];
            }

            return sum;
        }

        //3. Copy words from one file to another but only which of them that starts from S string.
        //4. Copy words from one file to another but only which of them that doesn't contain numbers.
        //5. *The text file contains pairs of numbers separated by a space (each pair of numbers is on new line). Considering each pair as the coordinates of points on the plane, find the largest and smallest distances between these points.
    }
}