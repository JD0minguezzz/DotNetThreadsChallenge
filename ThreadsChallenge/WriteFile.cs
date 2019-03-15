using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsChallenge
{
    class WriteFile
    {
        public WriteFile() {  }

        public void Write(List<string[]> rows, bool useLog)
        {
            string folderPath = @"C:\Users\jdominguez\OneDrive - ENDAVA\Documents\challenges\DotNetThreadsChallenge\People\";

            Log.SetLogger(useLog, "INFO", null, "Starting files creation...");
            foreach (var row in rows)
            {
                var path = folderPath + row[0] + ".txt";

                //Log.SetConsoleLogger(true, $"Creating file for ID: {int.Parse(row[0])}, age: ");
                Log.SetLogger(useLog, "INFO", null, $"Creating file for person with ID {int.Parse(row[0])} and name {row[2] + " " + row[4]}");

                TextWriter writer = new StreamWriter(path);
                foreach (var line in row)
                {
                    writer.WriteLine(line);
                }
                writer.Close();

                //Thread.Sleep(800);
            }
            Log.SetLogger(useLog, "INFO", null, "Files creation finished.");
        }
    }
}
