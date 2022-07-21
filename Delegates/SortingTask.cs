using System;
using System.Collections.Generic;

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

    public class SortingTask
    {
        public static List<User> sortUserBy(List<User> usersList, string sortBy = "LastName", bool ascending = true)
        {
            switch (sortBy)
            {
                case "FirstName":
                    usersList.Sort((x, y) =>
                    {
                        int ret = String.Compare(x.FirstName, y.FirstName);
                        return ret;
                    });
                    break;

                case "LastName":
                    usersList.Sort((x, y) =>
                    {
                        int ret = String.Compare(x.LastName, y.LastName);
                        return ret;
                    });
                    break;

                case "DateOfBirth":
                    usersList.Sort((x, y) =>
                    {
                        int ret = DateTime.Compare(x.DateOfBirth, y.DateOfBirth);
                        return ret;
                    });
                    break;

                case "PhoneNumber":
                    usersList.Sort((x, y) =>
                    {
                        int ret = String.Compare(x.PhoneNumber, y.PhoneNumber);
                        return ret;
                    });
                    break;

                default:
                    throw new ArgumentException("Unknown sorting!");
            }


            if (ascending == false)
            {
                usersList.Reverse();
            }

            return usersList;
        }

        private static (int, int) Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
            return (a, b);
        }
    }
}