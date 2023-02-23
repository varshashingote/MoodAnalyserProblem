using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser() { }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if(message.ToLower().Contains("sad"))
                {
                    Console.WriteLine("Given message \"{0}\" then \n retuern SAD",message);
                    return "SAD";
                }
               
             
                else
                {
                    Console.WriteLine("Given message \"{0}\" then \n retuern HAPPY", message);
                    return "HAPPY";
                }

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Given message \"{0}\" then \n retuern MoodAnalysisException",ex.Message);
                return "HAPPY";
  

            }

        }

    }
}
          