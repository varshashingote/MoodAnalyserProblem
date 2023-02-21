using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{
        public class CustomException : Exception
        {
            public ExceptionType exceptionType;
            public enum ExceptionType
            {
                Null_Mood,
                Empty_Mood,

            }
            public CustomException(String message, ExceptionType exception) : base(message)
            {
                this.exceptionType = exception;

            }

        }
}
