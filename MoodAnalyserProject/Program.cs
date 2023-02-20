using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How is your mood Happy or Sad");
            string message = Console.ReadLine();
            MoodAnalyser moodAnalyzer = new MoodAnalyser();
            Console.WriteLine(moodAnalyzer.AnalyseMood(message));

        }
    }
}
