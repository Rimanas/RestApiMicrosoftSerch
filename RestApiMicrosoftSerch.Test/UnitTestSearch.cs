using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Collections.Generic;

namespace RestApiMicrosoftSerch.Test
{
    public class TestsSearch
    {
        private static TestDataModel[] TestData = new TestDataModel[]
            {
               new TestDataModel
               {
                   Result = new Result { Title = "assasa", Descriptions = new List<Description> { new Description { Content = "asd" } } },
                   IsSuccess = true,
                   SearchString = "assasa"
               },
               new TestDataModel
               {
                   Result = new Result { Title = "LIN", Descriptions = new List<Description> { new Description { Content = "Q" } } },
                   IsSuccess = false,
                   SearchString = "LINQ"
               },
            };

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCaseSource("TestData")]
        public void Test1(TestDataModel testData)
        {
            bool search = Program.SearchString(testData.SearchString, testData.Result);
            Assert.That(search == testData.IsSuccess);
        }
    }
}