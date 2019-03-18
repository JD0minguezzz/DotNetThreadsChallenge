using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace ChallengeManager
{
    /// <summary>
    /// This class is responsible for the .csv file reading functionality,
    /// as well as assuring that the rows are suitable to insert into the DB.
    /// </summary>
    public class ReadCsv
    {
        /// <summary>
        /// Reads the .csv file provided and checks if the last field can be parsed to int.
        /// </summary>
        /// <returns>A list of string arrays containing valid rows.</returns>
        public static List<string[]> Read()
        {
            /// <value>System path where the .csv file is located.</value>
            string csvFilePath = @"C:\Users\jdominguez\ThreadData.csv";

            List<string[]> rows = new List<string[]>();
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
