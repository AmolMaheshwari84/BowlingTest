using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace CodingTest
{
    class Program
    {
        LoggingBlock loggerBlock = new LoggingBlock();
        static void Main(string[] args)
        {
            new Program().ReadFile();
            //Console.WriteLine("Enter Number of Frames");
            int noOfFrames = 10;
            int i = 1;

            
            bool isStrike = false;
            Bowling bowling = new Bowling();
            StringBuilder sb = new StringBuilder();
            while (i < noOfFrames*2 +4)
            {
                Console.WriteLine("Enter Roll");
                int intRoll = Convert.ToInt16(Console.ReadLine());

                bowling.Roll(intRoll);
                Console.WriteLine("This is your "+ i + " Roll");
                if (intRoll == 10 && i % 2 != 0)
                {
                    i = i+1;
                    sb.Append("[" + intRoll + " ]");
                    isStrike = true;

                    Console.WriteLine("It's a Strike!");
                }
                else
                {

                    if (i % 2 == 0 && !isStrike)
                    {
                        sb.Append(+intRoll + "]");
                        isStrike = false;
                    }
                    else
                    {
                        sb.Append("[ " + intRoll + " |");
                        isStrike = false;
                    }
            }
                i++;
            }
            Console.WriteLine(sb);
            
            Console.WriteLine("Bowling Score is =" + Convert.ToString(bowling.Score()));
        }
        public void ReadFile()
        {
            WriteTraceLog("Application Started!!!");

            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream("sample.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    WriteTraceLog(line);

                    list.Add(line);
                }
            }

            lines = list.ToArray();

            WriteTraceLog("Application Stopped!!!");
        }

        public void WriteTraceLog(String message)
        {
            loggerBlock.LogWriter.Write(message, "General", 5, 2000, TraceEventType.Information);
        }
    }
}
