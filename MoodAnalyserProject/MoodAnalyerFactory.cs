using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{
  
        public class MoodAnalyserFactory
        {
        
            //UC4- CreateMoodAnalyse method to create of MoodAnalyser class. 
      
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
                        throw new CustomException("Class Not Found", CustomException.ExceptionType.NO_SUCH_CLASS);
                    }
                }
                else
                {        
                    throw new CustomException("Constructor is not found",CustomException.ExceptionType.NO_SUCH_CONSTRUCTOR);
                }
            }
        }
}

