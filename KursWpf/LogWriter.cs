using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf
{
    public class LogWriter
    {
        private static LogWriter _logWriter;
        private string _directoryName = "logs";
        private string _fileName;
        //private DateTime _dateTime;


        private LogWriter() {
            //_dateTime = new DateTime();
        }

        public static LogWriter GetInst() {
            return _logWriter ?? (_logWriter = new LogWriter());
        }

        public void WriteFileL(string msg) {
            // TODO: Реализовать логирование, запись в файл входящей строки

            string logText = DateTime.Now.ToString("T") + " - " + msg;
            string fullPath = "";

            if (_fileName == null)
            {
                _fileName = "gameServer.log" + DateTime.Now.ToString("HHmmss dd-MM-yyyy") + ".txt";
            }

            if (!Directory.Exists(_directoryName))
            {
                Directory.CreateDirectory(_directoryName);

            }

            fullPath = _directoryName + "\\" + _fileName;

            using (StreamWriter sw = new StreamWriter(fullPath, true, System.Text.Encoding.Default)) {
                sw.WriteLineAsync(logText);
                
            }


        }

    }
}
