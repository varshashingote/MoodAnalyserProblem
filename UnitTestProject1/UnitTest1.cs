using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
using System;



namespace UnitTestProject1
{
    [TestClass]
    public class MoodAnalyerTestClass
    {
        //TC2-I am in any mood should return HAPPY
        [TestMethod]
        public void GivenAnyMoodRetuenHAPPY()
        {
           //arrange
            String message = "I am in happy mood";
            String exceptedValue = "HAPPY";
            MoodAnalyser mood = new MoodAnalyser(message);
            //Act
            String result = mood.AnalyseMood(message);
            //assert
            Assert.AreEqual(exceptedValue, result);
        }


        [TestMethod]
        public void GivenSadMoodMessage_WhenAnalyse_ShouldReturnSAD()
        {
            // i am sad mood should return SAD
            //arrange
            string message = "I am sad mood";
            string expectedValue = "SAD";
            MoodAnalyser moodAnalyser = new MoodAnalyser();
             //act
            string result = moodAnalyser.AnalyseMood(message);
            //assert
            Assert.AreEqual(expectedValue, result);
        }

    }
}
