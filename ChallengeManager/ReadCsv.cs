using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeManager
{
    public class ReadCsv
    {
        /// <summary>
        /// Reads a .csv file and returns a list of string arrays cotaining every row.  
        /// </summary>
        /// <returns></returns>
        public static List<string[]> Read()
        {
            List<string[]> rows = new List<string[]>();
            string csvFilePath = @"C:\Users\jdominguez\ThreadData.csv";
            using (TextFieldParser csvParser = new TextFieldParser(csvFilePath))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    if (int.TryParse(fields[fields.Length - 1], out var output))
                    {

                        rows.Add(fields);
                    }
                }
            }
            return rows;
        }
    }
}
