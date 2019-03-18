using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading;

namespace ChallengeManager
{   
    /// <summary>
    /// This class implements the Entity Framework to allow Person objects insertion into a SQL Server database.
    /// </summary>
    public class InsertPerson
    {
        private static void InsertRow(Person person, bool useLog)
        {
            using (PeopleDBEntities peopleDatabase = new PeopleDBEntities())
            {
                Log.SetLogger(useLog, "INFO", null, $"Inserting into database person with ID {person.id} and age {person.CalculateAge(person.birth_date)}");
                try
                {
                    peopleDatabase.People.Add(person);
                    peopleDatabase.SaveChanges();
                }
                catch (DbUpdateException exception)
                {
                    Log.SetLogger(useLog, "ERROR", exception, "Couldn't write to database.");
                }

                Thread.Sleep(800);
            }
        }

        /// <summary>
        /// The Insert method instantiates a Person object for each row from the .csv file and stores in the database.
        /// </summary>
        /// <param name="rows">List of string arrays containing the rows from the .csv file.</param>
        /// <param name="useLog">If true, allows the application to log information about its status.</param>
        public static void Insert(List<string[]> rows, bool useLog)
        {
            Log.SetLogger(useLog, "INFO", null, "Starting DB insertion...");
            foreach (var row in rows)
            {
                Person person = new Person();
                person.id = int.Parse(row[0]);
                person.title = row[1];
                person.first_name = row[2];
                person.middle_name = row[3];
                person.last_name = row[4];
                person.suffix = row[5];
                person.address_line1 = row[6];
                person.address_line2 = row[7];
                person.city = row[8];
                person.state_province_name = row[9];
                person.country_region_name = row[10];
                person.postal_code = row[11];
                person.phone_number = row[12];
                person.birth_date = DateTime.Parse(row[13]);
                person.education = row[14];
                person.occupation = row[15];
                person.gender = row[16];
                person.marital_status = row[17];
                person.home_owner_flag = int.Parse(row[18]);
                person.number_cars_owned = int.Parse(row[19]);
                person.number_children_at_home = int.Parse(row[20]);
                person.total_children = int.Parse(row[21]);
                person.yearly_income = int.Parse(row[22]);

                InsertRow(person, useLog);
            }
            Log.SetLogger(useLog, "INFO", null, "DB insertion finished.");
        }
    }
}
