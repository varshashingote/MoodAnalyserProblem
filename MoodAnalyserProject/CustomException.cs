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
            NO_SUCH_CLASS,
            NO_SUCH_CONSTRUCTOR,
        }
            public CustomException(String message, ExceptionType exception) : base(message)
            {
                this.exceptionType = exception;

            }

        }
}
