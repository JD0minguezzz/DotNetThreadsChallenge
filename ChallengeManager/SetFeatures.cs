using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeManager
{
    public class SetFeatures
    {
        public static void CheckState(bool[] states)
        {
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
                //ThreadStart aThread = new ThreadStart(WriteFiles);
                //ThreadStart bThread = new ThreadStart(InsertToDB);

                //Thread writeFileThread = new Thread(aThread);
                //Thread insertToDbThread = new Thread(bThread);

                //writeFileThread.Start();
                //insertToDbThread.Start();

                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }
        }

        /*private static void WriteFiles(bool useLog)
        {
            WriteFile.Write(rows, useLog);
        }*/

        /*private static void InsertToDB()
        {
            //var insertPerson = new InsertPerson();
            InsertPerson.Insert(rows, states[1]);
        }*/
    }
}
