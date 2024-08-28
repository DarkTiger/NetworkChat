using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CAClientCHAT
{
    public class LogClass
    {
                  
        public void WriteLog(int level, string message, string logLEVEL)
        {
            if (!File.Exists("Logs.txt"))
            {
                File.Create("Logs.txt");
            }

            string strLevel = "";
                
            switch (level)
	        {
                case 1: strLevel = "Level NORMAL"; break;
                case 2: strLevel = "Level INFO"; break;
                case 3: strLevel = "Level WARNING"; break;
                case 4: strLevel = "Level ERROR"; break;
            }


            if (logLEVEL == "INFO")
            {
                if (level == 2 || level == 3 || level == 4)
                {
                    using (StreamWriter sw = new StreamWriter("Logs.txt", true))
                    {
                        sw.WriteLine("\n" + DateTime.Now.ToString() + "   LEVEL: " + logLEVEL + "  " + message);
                        sw.Close();
                    }
                }
            }
            else if (logLEVEL == "WARN")
            {
                if (level == 3 || level == 4)
                {
                    using (StreamWriter sw = new StreamWriter("Logs.txt", true))
                    { 
                        sw.WriteLine("\n" + DateTime.Now.ToString() + "   LEVEL: " + logLEVEL + "  " + message);
                        sw.Close();
                    }
                }
            }
            else if (logLEVEL == "ERROR")
            {
                if (level == 4)
                {
                    using (StreamWriter sw = new StreamWriter("Logs.txt", true))
                    {
                        sw.WriteLine("\n" + DateTime.Now.ToString() + "   LEVEL: " + logLEVEL + "  " + message);
                        sw.Close();
                    }
                }
            }
            else if (logLEVEL == "DEBUG")
            {
                using (StreamWriter sw = new StreamWriter("Logs.txt", true))
                {
                    sw.WriteLine("\n" + DateTime.Now.ToString() + "   LEVEL: " + logLEVEL + "  " + message);
                    sw.Close();
                }
            }
        }
    
    }
}
