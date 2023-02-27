using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
using System;
namespace UnitTestProject1
{
    [TestClass]
    public class MoodAnalyerTestClass
    {
        [TestMethod]
        public void GivenNullMessage_Should_Return_UserMethod()
        {
                String message = null;
                String exceptedValue = "Message is Null";
            try { 
                MoodAnalyser mood = new MoodAnalyser(message);
                //Act
                String result = mood.AnalyseMood();
                Assert.AreEqual(exceptedValue, result);
            }
            catch(CustomException ex)
            {
                Assert.AreEqual(exceptedValue, ex.Message);
            }
        }
        [TestMethod]
        public void GivenEmptyMoodMessage_WhenAnalyse_ShouldReturn_UserMethod()
        {
            string message = "";
            string expectedValue = "Message is empty";
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);

                string result = moodAnalyser.AnalyseMood();

                Assert.AreEqual(expectedValue, result);
            }
            catch(CustomException ex)
            {
                Assert.AreEqual(expectedValue, ex.Message);
            }
        }
    }
}



