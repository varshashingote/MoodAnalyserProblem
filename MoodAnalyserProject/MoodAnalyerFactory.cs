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
    }
}


