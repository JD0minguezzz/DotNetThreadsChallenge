using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ThreadsChallenge
{
    class Program
    {
        static List<string[]> people = ReadCsv.Read();
        static bool[] states = Start.StartMenu();

        static void Main(string[] args)
        {
            CheckState();
            Console.ReadKey();
        }

        public static void CheckState()
        {
            if (states[2])
            {
                ThreadStart aThread = new ThreadStart(WriteFiles);
                Thread writeFileThread = new Thread(aThread);
                writeFileThread.Start();
            }
            if (states[3])
            {
                ThreadStart bThread = new ThreadStart(InsertToDB);
                Thread insertToDbThread = new Thread(bThread);
                insertToDbThread.Start();
            }
            if (states[4])
            {
                states[1] = true;
                ThreadStart aThread = new ThreadStart(WriteFiles);
                ThreadStart bThread = new ThreadStart(InsertToDB);

                Thread writeFileThread = new Thread(aThread);
                Thread insertToDbThread = new Thread(bThread);

                writeFileThread.Start();
                insertToDbThread.Start();

                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }
        }

        public static void WriteFiles()
        {
            var writeFile = new WriteFile();
            writeFile.Write(people, states[1]);
        }

        public static void InsertToDB()
        {
            var insertPerson = new InsertPerson();
            insertPerson.Insert(people, states[1]);
        }
    }
}
