using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsChallenge
{
    class Start
    {
        public static bool[] StartMenu()
        {
            string[] input;

            do
            {
                Console.WriteLine("Please select the features you want to execute:");
                Console.WriteLine();
                Console.WriteLine("1. Logging.");
                Console.WriteLine("2. File storing.");
                Console.WriteLine("3. DB insertion.");
                Console.WriteLine("4. All features.");
                Console.WriteLine();
                input = Console.ReadLine().Split(' ');
                Console.WriteLine();
            }
            while (!ValidateInput(input));

            return States(input);
        }

        private static bool[] States(string[] input)
        {
            bool[] states = new bool[5];
            foreach (var value in input)
            {
                states[int.Parse(value)] = true;
            }
            return states;
        }

        private static bool ValidateInput(string[] input)
        {
            bool isValid = false;
            if (input.Length > 4)
            {
                return isValid; 
            }
            foreach (var value in input)
            {
                if (int.TryParse(value, out int output))
                {
                    if (Enumerable.Range(1, 4).Contains(output))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else isValid = false;
            }
            return isValid;
        }
    }
}
