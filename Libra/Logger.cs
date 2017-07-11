using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Libra
{
	public class LoggerException : Exception
	{
		public LoggerException(string message) : base(message) { }
	}


	public class Logger
	{
		private static Logger instance;
		public static FileStream File = new FileStream((string)Properties.Settings.Default["DefaultLogFile"], FileMode.Create, FileAccess.Write);
		public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

		public enum Level { Info, Debug, Warning, Error, Fatal };

		public static void Write(Level level, string text)
		{
			var output = String.Format("{0} [{1}] {2}\n",
				DateTime.Now.ToString(DateTimeFormat), Enum.GetName(typeof(Level), level), text);
			if (File == null || !File.CanWrite)
				throw new LoggerException("Log file cannot be accessed");

			File.Write(Encoding.UTF8.GetBytes(output), 0, output.Length);
			File.Flush();

		}

		public static void WriteException(Level level, Exception e)
		{
			Write(level, e.Message + "\nStack Trace:" + e.StackTrace);
		}

		public Logger()
		{

		}

		public static Logger Instance
		{
			get
			{
				if (instance == null)
					instance = new Logger();
				return instance;
			}
		}
	}
}

