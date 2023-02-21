using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
using System;
namespace UnitTestProject1
{
    [TestClass]
    public class MoodAnalyerTestClass
    {
        [TestMethod ]
        public void GivenNullMoodShouldReturnHAPPY()
        {
            string expected = "HAPPY";
            string message = "NULL";
            MoodAnalyser moodAnalyse = new MoodAnalyser(message);
            string mood = moodAnalyse.AnalyseMood(message);
            Assert.AreEqual(expected, mood);
        }

    }
}

