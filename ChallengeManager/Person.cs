namespace ChallengeManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public int id { get; set; }
        public string title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string suffix { get; set; }
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string city { get; set; }
        public string state_province_name { get; set; }
        public string country_region_name { get; set; }
        public string postal_code { get; set; }
        public string phone_number { get; set; }
        public DateTime birth_date { get; set; }
        public string education { get; set; }
        public string occupation { get; set; }
        public string gender { get; set; }
        public string marital_status { get; set; }
        public int home_owner_flag { get; set; }
        public int number_cars_owned { get; set; }
        public int number_children_at_home { get; set; }
        public int total_children { get; set; }
        public int yearly_income { get; set; }

        public int CalculateAge(DateTime birthDate)
        {
            int age = 0;
            age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
