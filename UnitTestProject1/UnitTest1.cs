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
      
        [TestMethod]
        [DataRow(null, "HAPPY")]
        //UC2-GivenNull return happy
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

        /// <summary>
        /// TC3.1-Given NULL mood Should Throw MoodAnalysisException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="excepted"></param>
        [TestMethod]
        [DataRow(null, "Message is having null")]
        public void GivenNULLMoodWhenAnalyzerShouldThrowMoodAnalysisException(string message, string excepted)
        {
            try
            {
                //AAA Methodology
                //Arrange
                MoodAnalyser mood = new MoodAnalyser(message);

                //Act
                string actual = mood.AnalyseMood();

                //Assert
                Assert.AreEqual(excepted, actual);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(excepted, ex.Message);
            }
        }
   
        [TestMethod]
        [DataRow("", "Message is having empty")]
        public void GivenEMPTYMoodWhenAnalyzerShouldThrowMoodAnalysisException(string message, string excepted)
        {
            try
            {
                //AAA Methodology
                //Arrange
                MoodAnalyser mood = new MoodAnalyser(message);

                //Act
                string actual = mood.AnalyseMood();

                //Assert
                Assert.AreEqual(excepted, actual);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(excepted, ex.Message);
            }
        }  /// <summary>
           /// TC4.1- Given MoodAnalyser ClassName Should Return MoodAnalyser Object
           /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturnMoodAnalyserObject()
        {
            object excepted = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            excepted.Equals(obj);
        }

        /// <summary>
        /// /*TC4.2 Given Class Name When Improper_ShouldThrowMoodAnalyserExpection*/
        /// </summary>
        [TestMethod]
        public void GivenClassNameWhenImproperShouldThrowMoodAnalyserExpection()
        {
            string exceptedMsg = "Class Not Found";
            try
            {
                // MoodAnalyser actual = (MoodAnalyser)MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");//proper className and prober constructorname
                Object excepted = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.Customer", "Customer");
                actual.Equals(excepted);
            }
            catch (CustomException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(exceptedMsg, ex.Message);
            }
        }

        /// <summary>
        /// /*TC4.3- GivenClassWhenConstructorNotProper_ShouldThrowMoodAnalyserExpection*/
        /// </summary>
        [TestMethod]
        public void GivenClassWhenConstructorNotProperShouldThrowMoodAnalyserExpection()
        {
            string exceptedMsg = "Constructor is not found";
            try
            {
                Object excepted = new MoodAnalyser();
                Object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerProblem.MoodAnalyser", "Customer");
                actual.Equals(excepted);
            }
            catch (CustomException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(exceptedMsg, ex.Message);
            }
        }
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser")]//UC4.1Check Two Object are equal or not
        [DataRow("MoodAnalyser", "MoodAnalyser")]//UC4.2 Improper class name and throws error
        [DataRow("MoodAnalyserProject.MoodAnalyser", "Mood")]//UC4.2 Improper Constructor name and throw exception
        [TestMethod]
        public void GivenMoodAnalyerclassName_ReturnMoodAnalyerObjectofthatClass(String className, String constructorname)
        {
            try
            {
                Object excepted = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateMoodAnalyse(className, constructorname);
                excepted.Equals(actual);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(ex.Message, "Constructor is not found");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Class not found");
            }

        }
        [TestMethod] //UC^.1 Given Happy return happy.
        public void GivenHappyMoodShouldReturnhapppy()
        {
            String excepted = "HAPPY";
            String mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(excepted, mood);

        }
        [TestMethod]
        public void GiveHappyMessageWithReflectorShouldReturnHAPPY()
        {
            string result = MoodAnalyserFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }
        /// <summary>
        ///  /*TC7.2 Set Field When Improper Should Throw Exception with No Such Field*/
        /// </summary>
        [TestMethod]
        public void SetFieldWhenImproperShouldThrowExceptionwithNoSuchField()
        {
            string expected = "Field is Not Found";
            try
            {
                string mood = MoodAnalyserFactory.SetField("Happy", "Customer");
            }
            catch (CustomException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        ///  /*TC7.3 Setting Null Message with Reflector Should Throw Exception*/
        /// </summary>
        [TestMethod]
        public void SetNullMessagewithReflectorShouldThrowException()
        {
            string expected = "Message should not be null";
            try
            {
                string mood = MoodAnalyserFactory.SetField(null, "AnalyserMood");
            }
            catch (CustomException ex)
            {
                Console.Write("\"{0}\"", ex.Message);
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}

    
    

      