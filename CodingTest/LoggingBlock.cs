using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class LoggingBlock
    {
        protected LogWriter logWriter;

        public LoggingBlock()
        {
            InitLogging();
        }

        private void InitLogging()
        {
            logWriter = new LogWriterFactory().Create();
            Logger.SetLogWriter(logWriter, false);
        }

        public LogWriter LogWriter
        {
            get
            {
                return logWriter;
            }
        }
    }
}
