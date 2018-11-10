using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf
{
    public class LogWriter
    {
        private static LogWriter _logWriter;

        private LogWriter() {
        }

        public static LogWriter GetInst() {
            return _logWriter ?? (_logWriter = new LogWriter());
        }

        public void WriteFileL(string msg) {

            // TODO: Реализовать логирование, запись в файл входящей строки
        }

    }
}
