using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftSunlight.Tool
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class Log
    {
        private static string filePath = Path.Combine(Assembly.GetExecutingAssembly().Location, "Log\\" + DateTime.Today.ToString("yyyy-MM-dd") + "_log.txt");
        public static void Write(string message)
        {
            Write(message, null);
        }

        public static void Write(string message, Exception ex)
        {
            try
            {
                File.AppendAllText(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + GetContent(message, ex));
            }
            catch (FileLoadException fileLoadException)
            {
                string[] files = Directory.GetFiles(Path.Combine(Assembly.GetExecutingAssembly().Location, "Log\\"));
                Regex regex = new Regex(DateTime.Today.ToString("yyyy-MM-dd") + @"_log_?(?<number>_\d+)?\.txt");
                int maxIndex = 1;
                foreach (string file in files)
                {
                    Match m = regex.Match(file);
                    if (m.Success)
                    {
                        if (m.Groups["number"].Success)
                        {
                            maxIndex = Convert.ToInt32(m.Groups["number"].Value);
                        }
                    }
                }
                filePath = Path.Combine(Assembly.GetExecutingAssembly().Location, "Log\\" + DateTime.Today.ToString("yyyy-MM-dd") + "_log_" + maxIndex + ".txt");
                Write(message, ex);
            }
        }

        private static StringBuilder GetContent(string message, Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(message).Append(Environment.NewLine).Append(ex.Message + "," + ex.Source + "," + ex.StackTrace).Append(Environment.NewLine);
            if (ex.InnerException != null)
            {
                stringBuilder.Append(GetContent(string.Empty, ex.InnerException));
            }
            return stringBuilder;
        }

    }
}
