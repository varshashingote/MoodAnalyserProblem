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
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood(string message)
        {
            try
            {
                if (message.ToUpper().Contains("SAD"))
                {

                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
               
            }
            catch (NullReferenceException ex)
            {
                return "HAPPY";
            }


        }

    }
}
