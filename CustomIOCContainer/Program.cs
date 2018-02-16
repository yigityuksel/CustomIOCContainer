using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomIOC;
using CustomIOCContainer.CustomContainer;
using CustomIOCContainer.Interfaces;
using CustomIOCContainer.Logger;

namespace CustomIOCContainer
{
    class Program
    {
        static void Main(string[] args)
        {

            ////register to IOC
            //DependencyContainer.Register<ILogger, Logger.Logger>();
            //DependencyContainer.Register<IConsoleLogger, ConsoleLogger>();

            //var consoleLogger = DependencyContainer.Resolve<IConsoleLogger>();

            //consoleLogger.DisplayMessage("Test Message");

            var container = new Container();

            container.Register<ILogger,Logger.Logger>();
            container.Register<IConsoleLogger, ConsoleLogger>();

            var consoleLogger = container.Resolve<IConsoleLogger>();

            consoleLogger.DisplayMessage("Test message");

        }
    }
}
