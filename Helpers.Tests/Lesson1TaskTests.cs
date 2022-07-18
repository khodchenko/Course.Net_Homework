using NUnit.Framework;
using Helpers;

namespace Helpers.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {//AAA
            //Arrange
            int hours = 1;
            int expected = 60;
            //Act
            int actual = Lesson1Task.HoursToMinutes(hours);
            //Assert
            
            Assert.AreEqual(expected, actual);
        }
    }
}