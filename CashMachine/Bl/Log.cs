using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using CashMachine.Models;

namespace CashMachine.Bl
{
    public class Log
    {
        public Log()
        {
            LogFilePath = ConfigurationManager.AppSettings["PathLog"];
            LogFilePath += DateTime.Today.ToString("yyyyMMdd") + "_Log.csv";
        }
        public string LogFilePath { get; set; }
        private static StringBuilder TextEntryLog(ErrorVm logEntry)
        {
            var sb = new StringBuilder();
            sb.Append(Assembly.GetExecutingAssembly().GetName().Name).Append("|");
            sb.Append(logEntry.CardNumber).Append("|");
            sb.Append(logEntry.ErrorMessage.Replace(Environment.NewLine, " ")).Append("|");
            sb.Append(logEntry.ErrorId).Append("|");
            sb.Append(DateTime.Now);
            return sb;
        }
        private static StringBuilder TextHeader()
        {
            var sb = new StringBuilder();
            sb.Append("Source").Append("|");
            sb.Append("CardNumber").Append("|");
            sb.Append("Message").Append("|");
            sb.Append("Code").Append("|");
            sb.Append("CreationDate");
            return sb;
        }
        public void LogEntry(ErrorVm logEntry)
        {
            var logFileInfo = new FileInfo(LogFilePath);
            var logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            var isnew = !logFileInfo.Exists;
            var fileStream = isnew ? logFileInfo.Create() : new FileStream(LogFilePath, FileMode.Append);
            var sb = TextEntryLog(logEntry);
            var log = new StreamWriter(fileStream);
            if (isnew)
            {
                log.WriteLine(TextHeader().ToString());
            }
            log.WriteLine(sb.ToString());
            log.Close();
        }
    }
}