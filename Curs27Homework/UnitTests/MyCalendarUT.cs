using Curs27Homework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class MyCalendarUT
    {
        [TestFixture]
        public class MyCalendarUnitTests
        {
            private MyCalendar myCalendar;

            [SetUp]
            public void Setup()
            {
                myCalendar = new MyCalendar();
            }

            [Test]
            public void Book()
            {
                //arrange
                var start = 10;
                var end = 20;
                var expected = true;

                //act
                var actual = myCalendar.Book(start, end);

                //assert
                Assert.AreEqual(expected, actual);
            }

            [TestCase(5, 15, ExpectedResult = false)]
            [TestCase(51, 65, ExpectedResult = false)]
            public bool BookTestCases(int s, int e)
            {
                //arrange
                var start = s;
                var end = e;

                //prepaire scenario
                myCalendar.Book(10, 20);
                myCalendar.Book(50, 60);
                myCalendar.Book(10, 40);
                myCalendar.Book(5, 10);
                myCalendar.Book(25, 55);

                //act
                return myCalendar.Book(start, end);
            }
        }
    }
}
