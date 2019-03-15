using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsChallenge
{
    class Log
    {
        public Log() {  }

        private static void ConfigLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logFile = new NLog.Targets.FileTarget("logfile") {
                FileName = "log.txt",
                Layout = @"${longdate} - ${level:uppercase=true}: ${message}${onexception:${newline}EXCEPTION\: ${exception:format=ToString}}"
            };
            //var logConsole = new NLog.Targets.ConsoleTarget("logconsole") {  };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
            //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logConsole);

            NLog.LogManager.Configuration = config;
        }

        private static void InfoMessage(string message)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info(message);
        }

        private static void ErrorMessage(Exception exception, string message)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Error(exception, message);
        }

        private static void WarnMessage(string message)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Warn(message);
        }

        public static void SetLogger(bool useLog, string messageType, Exception exception, string message)
        {
            if (useLog)
            {
                ConfigLogger();
                if (messageType.Equals("INFO"))
                {
                    InfoMessage(message);
                }
                if (messageType.Equals("ERROR"))
                {
                    ErrorMessage(exception, message);
                }
                if (messageType.Equals("WARN"))
                {
                    WarnMessage(message);
                }
            }
        }

        public static void SetConsoleLogger(bool useLog, string message)
        {
            ConfigLogger();
            InfoMessage(message);
        }
    }
}
