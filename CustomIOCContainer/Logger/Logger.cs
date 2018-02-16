using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomIOCContainer.Interfaces;

namespace CustomIOCContainer.Logger
{
   public class Logger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine(value);
        }
    }
}
