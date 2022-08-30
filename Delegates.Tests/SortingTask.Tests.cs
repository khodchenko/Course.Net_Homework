using System.Collections.Generic;
using NUnit.Framework;
using Delegates;

namespace Delegates.Tests
{
    public abstract class SortingTaskTests <T> where T : SortingTask
    {
        public abstract SortingTask CreateListOfUsers(int[] sourceArray);
        
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 1, 2, 3, 4, 5, 10 })]
        public void AddBack_WhenArrayNotEmpty_ShouldAddToBack
            (int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var userList = CreateListOfUsers(sourceArray);

            

            CollectionAssert.AreEqual(expectedArray, userList);
        }
    }
}