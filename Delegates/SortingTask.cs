using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Delegates
{
    public class User
    {
        public User(string lastName, string firstName, DateTime dateOfBirth, string phoneNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {DateOfBirth} {PhoneNumber}";
        }
    }

    public class SortingTask : List<User>
    {
        static void Sort<T>(T[] items, Func<T,T, int> comparer ) where T : IComparable<T>
        {
            if (items == null)
            {
                throw new ArgumentException(nameof(items));
            }

            for (int i = 0; i < items.Length -1; i++)
            {
                for (int j = 0; j < items.Length; j++)
                {
                    if (comparer.Invoke(items[i],items[j]) == 1)
                    {
                        Swap(ref items[i], ref items[j]);
                    }
                }
            }
        }

        static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            if (items == null || predicate == null)
            {
                throw new ArgumentException(nameof(items));
            }

            foreach (var item in items)
            {
                throw new NotImplementedException();
            }

            yield break; 
        }

        private static void Swap<T>(ref T a, ref T b) where T : IComparable<T>
        {
            (a, b) = (b, a);
        }

    }
}