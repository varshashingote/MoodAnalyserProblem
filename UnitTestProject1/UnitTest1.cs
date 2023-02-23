using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProject;
using System;
namespace UnitTestProject1
{
    [TestClass]
    public class MoodAnalyerTestClass
    {
        /// <summary>
        ///  /*TC1.1 Given “I am in Sad Mood” message Should Return SAD*/
        ///  /*TC1.2 Given “I am in Any Mood” message Should Return HAPPY*/
        ///  TC2.1-Given NULL mood Should Return HAPPY
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        [DataRow("I am in Sad Mood", "SAD")]
        [DataRow("I am in Any Mood", "HAPPY")]
        //[DataRow(null, "HAPPY")]
        public void GivenMessageWhenAnalyzerShouldReturnMood(string message, string excepted)
        {
            //AAA Methodology
            //Arrange
            MoodAnalyser mood = new MoodAnalyser(message);

            //Act
            string actual = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(excepted, actual);
        }
        /// <summary>
        /// TC3.1-Given NULL mood Should Throw MoodAnalysisException
        /// TC3.2-Given EMPTY mood Should Throw MoodAnalysisException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        [DataRow(null, "HAPPY")]
        
        public void GivenNULLMessageWhenAnalyzerShouldReturnHAPPYMood(string message, string excepted)
        {
            //AAA Methodology
            //Arrange
            MoodAnalyser mood = new MoodAnalyser(message);

            //Act
            string actual = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(excepted, actual);
        }
    }
}

    

      