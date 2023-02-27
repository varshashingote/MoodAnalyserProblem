using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyser
    {
      /*UC1Given a Message, ability
        to analyse and respond
         Happy or Sad Mood*/
        
        public string MoodAnalyser(string message)
        {
                if (message.ToLower().Contains("Sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            
        }
    }
}
