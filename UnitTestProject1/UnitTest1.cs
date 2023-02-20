using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
using System;



namespace UnitTestProject1
{
    [TestClass]
    public class MoodAnalyerTestClass

    {
        [TestMethod]
        public void Given_Message_Should_Return_UserMethod()
        {
           
            String message = "I am in happy mood";
            String exceptedValue = "HAPPY";
            MoodAnalyser mood = new MoodAnalyser(message);
            //Act
            String result = mood.AnalyseMood(message);
            Assert.AreEqual(exceptedValue, result);
        }


        [TestMethod]
        public void GivenSadMoodMessage_WhenAnalyse_ShouldReturnSAD()
        {

            string message = "I am sad mood";
            string expectedValue = "SAD";
            MoodAnalyser moodAnalyser = new MoodAnalyser();

            string result = moodAnalyser.AnalyseMood(message);

            Assert.AreEqual(expectedValue, result);
        }



    }
}
