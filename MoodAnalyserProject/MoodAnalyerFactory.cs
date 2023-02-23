using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{

    public class MoodAnalyserFactory
    {
        /// <summary>
        /// UC4- CreateMoodAnalyse method to create of MoodAnalyser class. 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException"></exception>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            bool result = Regex.IsMatch(className, pattern);
            if (result)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (Exception)
                {
                    Console.WriteLine("When Class Name ==> \"{0}\" is Improper so here \nthrow MoodAnalyserExpection", className);
                    throw new CustomException("Class Not Found", CustomException.ExceptionType.NO_SUCH_CLASS);
                }
            }
            else
            {
                Console.WriteLine("Here ClassName \"{0}\" is proper but\nConstructorName \"{1}\" is Improper\nSo here throw MoodAnalysisException", className, constructorName);
                throw new CustomException("Constructor is not found", CustomException.ExceptionType.NO_SUCH_CONSTRUCTOR);
            }

        }
        public static object CreateMoodAnalyseUsingParamerizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            { 
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(String) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;

                }
                else
                {
                    Console.WriteLine("Here ClassName \"{0}\" is proper but\nConstructorName \"{1}\" is Improper\nSo here throw MoodAnalysisException", className, constructorName);
                    throw new CustomException("Constructor is not found", CustomException.ExceptionType.NO_SUCH_CONSTRUCTOR);
                }
            }
            else
            {
                Console.WriteLine("When Class Name ==> \"{0}\" is Improper so here \nthrow MoodAnalyserExpection", className);
                throw new CustomException("Class Not Found", CustomException.ExceptionType.NO_SUCH_CLASS);


            }

        }
        public static String InvokeAnalyseMood(String message,String MethodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserProject.MoodAnalyser");
                object MoodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyseUsingParamerizedConstructor("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo analyseMoodInfo = type.GetMethod(MethodName);
                object mood = analyseMoodInfo.Invoke(MoodAnalyserObject, null);
                return mood.ToString();

            }
            catch(NullReferenceException)
            {
                throw new  CustomException("No_Such_Method" ,CustomException.ExceptionType.NO_SUCH_METHOD);
            }
        }
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    Console.WriteLine("Setting \"Null\" message with Reflector should throw Exception ");
                    throw new CustomException("Message should not be null", CustomException.ExceptionType.NO_SUCH_FIELD);
                }
                field.SetValue(moodAnalyser, message);
             
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Set field when Improper ==> \"{0}\" should \nthrow Exception ", fieldName);
                throw new CustomException("Field is Not Found", CustomException.ExceptionType.NO_SUCH_FIELD);
            }
        }
    }
}


 

