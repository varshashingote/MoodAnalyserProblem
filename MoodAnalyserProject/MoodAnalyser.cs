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
        public MoodAnalyser(){ }         
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

                    return "SAD";
                }
               
               else if(message.Equals(String.Empty))
                {
                    throw new CustomException("Message is empty", CustomException.ExceptionType.Empty_Mood);
                }
                else
                {
                    return "HAPPY";
                }

            }
            catch (NullReferenceException ex)
            {
                throw new CustomException("Message is Null", CustomException.ExceptionType.Null_Mood);

            }

        }

    }
}
          