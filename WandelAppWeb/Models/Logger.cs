using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace WandelAppWeb.Models
{
    public class Logger
    {
        public void WriteToLog(string entry)
        {
            string logString = "Loggy Boi! [" + DateTime.Now.TimeOfDay.ToString() + "] - " + entry;
            Debug.WriteLine(logString);
            // Write to actual log file
        }
    }
}