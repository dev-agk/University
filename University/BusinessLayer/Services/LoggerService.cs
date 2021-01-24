using System;
using System.Diagnostics;
using University.BusinessLayer.Interfaces;

namespace University.BusinessLayer.Services
{
    public class LoggerService : ILoggerInterface
    {
        public void Log(string message)
        {
            Debug.WriteLine("|" + DateTime.Now.ToString() + "|" + message);
        }
    }
}
