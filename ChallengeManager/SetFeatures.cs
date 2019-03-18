using System.Collections.Generic;
using System.Threading;

namespace ChallengeManager
{
    /// <summary>
    /// This class contains the operations necessary to process user input.
    /// </summary>
    public class SetFeatures
    {
        /// <summary>
        /// Establishes the specific threads to be implemented, depending on the features that the user wants to execute.
        /// </summary>
        /// <param name="states">Boolean array that determines whether a feature is on or off.</param>
        public static void CheckState(bool[] states)
        {
            /// <value>List of string arrays containing the rows result of the .csv file reading.</value>
            List<string[]> rows = ReadCsv.Read();

            if (states[2])
            {
                Thread writeFileThread = new Thread(() => WriteFile.Write(rows, states[1]));
                writeFileThread.Start();
            }
            if (states[3])
            {
                Thread insertToDbThread = new Thread(() => InsertPerson.Insert(rows, states[1]));
                insertToDbThread.Start();
            }
            if (states[4])
            {
                states[1] = true;

                Thread writeFileThread = new Thread(() => WriteFile.Write(rows, states[1]));
                Thread insertToDbThread = new Thread(() => InsertPerson.Insert(rows, states[1]));
                writeFileThread.Start();
                insertToDbThread.Start();
            }
        }
    }
}
