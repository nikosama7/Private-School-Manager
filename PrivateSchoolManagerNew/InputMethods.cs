using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolManagerNew
{
    public class InputMethods
    {
        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static string ReadInput(string message)
        {
            string input = ReadString(message);
            while (input == "")
            {
                Console.WriteLine("Invalid string input!");
                input = ReadString(message);
            }
            return input;
        }

        public static void ReadFullName(out string FirstName, out string LastName, string person)
        {
            FirstName = ReadInput($"Insert the first name of a {person}: ");
            LastName = ReadInput($"Insert the last name of a {person}: ");
        }

        public static int ReadID(string person, string message)
        {
            int option;
            string input = ReadInput($"Insert the number ID of the {person} you want to {message}: ");
            while (!int.TryParse(input, out option) || option <= 0)
            {
                Console.WriteLine("Invalid Input");
                input = ReadInput($"Insert again the number ID of the {person} you want to {message}: ");
            }
            return option;
        }

        public static void Cancel()
        {
            Console.WriteLine("You are returning to previous menu.\n");
        }

        public static DateTime ReadDate(string message)
        {
            string input = ReadInput(message);
            DateTime option;
            while (!DateTime.TryParse(input, out option) || option.DayOfWeek > DayOfWeek.Friday || option.DayOfWeek < DayOfWeek.Monday)
            {
                Console.WriteLine("Invalid Input");
                input = ReadInput(message);
            }
            return option;
        }

        public static DateTime ReadEndDate(string message, DateTime startTime)
        {
            string input = ReadInput(message);
            DateTime option;
            while (!DateTime.TryParse(input, out option) || option < startTime || option.DayOfWeek > DayOfWeek.Friday || option.DayOfWeek < DayOfWeek.Monday)
            {
                Console.WriteLine("Invalid Input");
                input = ReadInput(message);
            }
            return option;
        }

        public static DateTime ReadDoB()
        {
            string input = ReadInput("Insert the date of birth: ");
            DateTime option;
            while (!DateTime.TryParse(input, out option) || option > DateTime.Now || option < new DateTime(1900,1,1))
            {
                Console.WriteLine("Invalid Input");
                input = ReadInput("Insert the date of birth: ");
            }
            return option;
        }

        public static decimal ReadFees()
        {
            string input = ReadInput("Insert the tuition fees: ");
            decimal option;
            while (!decimal.TryParse(input, out option) || (option < 0.0m))
            {
                Console.WriteLine("Invalid Input");
                input = ReadInput("Insert again the tuition fees: ");
            }
            return option;
        }

        public static decimal ReadMarks(string message)
        {
            string input = ReadInput(message);
            decimal option;
            while (!decimal.TryParse(input, out option) || option < 0.0m || option > 100.0m)
            {
                Console.WriteLine("Invalid Input");
                input = ReadInput(message);
            }
            return option;
        }
    }
}
