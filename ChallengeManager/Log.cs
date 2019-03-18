using NLog;
using System;

namespace ChallengeManager
{
    /// <summary>
    /// This class encompass the log system used in the application, allowing different types of messages and targets (file and console).
    /// </summary>
    public class Log
    {
        private static void ConfigLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logFile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = "log.txt",
                Layout = @"${longdate} - ${level:uppercase=true}: ${message}${onexception:${newline}EXCEPTION\: ${exception:format=ToString}}"
            };
            var logConsole = new NLog.Targets.ConsoleTarget("logConsole");

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logConsole);

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

        /// <summary>
        /// This method configures the logger, depending on the user input and the type of message that needs to be logged. 
        /// </summary>
        /// <param name="useLog">If true, allows the application to log its status.</param>
        /// <param name="messageType">The message type to log (INFO, ERROR, WARN)</param>
        /// <param name="exception">This parameter is used when the message type is ERROR, allowing the log to show the exception encountered.</param>
        /// <param name="message">The message to log.</param>
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
    }
}
