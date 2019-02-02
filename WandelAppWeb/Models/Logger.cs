using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace WandelAppWeb.Models
{
    public class Logger
    {
        /// <summary>
        /// Write a line in the Output of Visual Studio.
        /// </summary>
        /// <param name="entry"></param>
        public void WriteToLog(string entry)
        {
            string logString = "Loggy Boi! [" + DateTime.Now.TimeOfDay.ToString() + "] - " + entry;
            Debug.WriteLine(logString);
        }
    }
}