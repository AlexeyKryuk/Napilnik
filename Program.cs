using System;
using System.IO;

namespace Napilnik
{
    interface ILogger
    {
        void Log(string message);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pathfinder fileLog = new Pathfinder(new FileLogWritter("log.txt"), "File Log");
            Pathfinder consoleLog = new Pathfinder(new ConsoleLogWritter(), "Console Log");
            Pathfinder secureFileLog = new Pathfinder(new SecureLogWritter(new FileLogWritter("secureLog.txt")), "Secure File Log");
            Pathfinder secureConsoleLog = new Pathfinder(new SecureLogWritter(new ConsoleLogWritter()), "Secure Console Log");
            Pathfinder secureFileAndConsoleLog = new Pathfinder(new ConsoleLogWritter(new SecureLogWritter(new FileLogWritter("secureLog2.txt"))), "Console and Secure File Logs");

            fileLog.Find();
            consoleLog.Find();
            secureFileLog.Find();
            secureConsoleLog.Find();
            secureFileAndConsoleLog.Find();
        }
    }

    class Pathfinder
    {
        private ILogger _logger;
        private string _logMessage;

        public Pathfinder(ILogger logger, string logMessage = null)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
            _logMessage = logMessage;
        }

        public void Find()
        {
            _logger.Log(_logMessage);
        }
    }

    class ConsoleLogWritter : ILogger
    {
        private ILogger _logger;

        public ConsoleLogWritter(ILogger logger = null)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            Console.WriteLine(message);

            if (_logger != null)
                _logger.Log(message);
        }
    }

    class FileLogWritter : ILogger
    {
        private ILogger _logger;
        private string _filename;

        public FileLogWritter(string filename, ILogger logger = null)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(filename);

            _filename = filename;
            _logger = logger;
        }

        public void Log(string message)
        {
            File.WriteAllText(_filename, message);

            if (_logger != null)
                _logger.Log(message);
        }
    }

    class SecureLogWritter : ILogger
    {
        private ILogger _logWritter;

        public SecureLogWritter(ILogger logWritter)
        {
            if (logWritter == null)
                throw new ArgumentNullException(nameof(logWritter));

            _logWritter = logWritter;
        }

        public void Log(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _logWritter.Log(message);
            }
        }
    }
}
