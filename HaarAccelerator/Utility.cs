using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HaarAccelerator
{
    public class Logger
    {
        private string _logPath { get; }
        private StreamWriter Log { get; set; }
        public Logger(string logPath)
        {
            _logPath = logPath + "\\HaarClassifier.log";
        }
        public void Write(string logContent,LogType logType)
        {
            if (!string.IsNullOrEmpty(logContent) && !string.IsNullOrEmpty(_logPath))
            {
                if (File.Exists(_logPath))
                {
                    Log = File.AppendText(_logPath);
                }
                else
                {
                    Log = File.CreateText(_logPath);
                }
                Log.WriteLine($"[{logType}][Time:{DateTime.Now} {Utility.GetTimeStamp()}] {logContent}");
                Log.Close();
            }
            else
            {
                throw new Exception("Logcontent or path is empty!");
            }
            
        }
        public void OpenLog()
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", _logPath);
            }
            catch
            {
                MessageBox.Show("Please check the file's path!");
            }
        }
        public enum LogType
        {
            Info = 0,
            Error = 1,
            OpenCV = 2
        }
    }

    public class Utility
    {
        //摸摸昊哥哥的代码，我是fw
        public static string GetFileHash(string path)
        {
            var hash = SHA1.Create();
            var stream = new FileStream(path, FileMode.Open);
            byte[] hashByte = hash.ComputeHash(stream);
            stream.Close();
            return BitConverter.ToString(hashByte).Replace("-", "");
        }

        public static long GetTimeStamp()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;
            return timeStamp;
        }
    }
}
