using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ChallengeManager
{
    /// <summary>
    /// This class takes care of the text files creation associated with the rows from the .csv file. 
    /// </summary>
    public class WriteFile
    {
        /// <summary>
        /// Creates a .txt file for each row passed to it and stores it in the People folder.
        /// </summary>
        /// <param name="rows">List of string arrays containing the rows from the .csv file.</param>
        /// <param name="useLog">If true, allows the application to log information about its status.</param>
        public static void Write(List<string[]> rows, bool useLog)
        {
            /// <value>Folder path where the .txt files are going to be stored.</value>
            string folderPath = @"C:\Users\jdominguez\OneDrive - ENDAVA\Documents\challenges\DotNetThreadsChallenge\People\";

            Log.SetLogger(useLog, "INFO", null, "Starting files creation...");
            foreach (var row in rows)
            {
                Log.SetLogger(useLog, "INFO", null, $"Creating file for person with ID {int.Parse(row[0])} and name {row[2] + " " + row[4]}");
                var path = folderPath + row[0] + ".txt";
                TextWriter writer = new StreamWriter(path);
                foreach (var line in row)
                {
                    writer.WriteLine(line);
                }
                writer.Close();

                Thread.Sleep(1000);
            }
            Log.SetLogger(useLog, "INFO", null, "Files creation finished.");
        }
    }
}
