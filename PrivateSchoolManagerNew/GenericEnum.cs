using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolManagerNew
{
    public static class GenericEnum
    {
        public static int InsertOption<T>()
        {
            int option;
            string input;
            Console.WriteLine("\nWhat\'s your next action?\n");
            do
            {
                input = InputMethods.ReadInput("Insert your choice: ");
            } while (!int.TryParse(input, out option) || ((option > (Enum.GetNames(typeof(T)).Length - 2) || option < 0) && option != 100));
            return option;
        }

        public static int ReadStreamOrTypeOrRole<T>(string message)
        {
            string input = InputMethods.ReadInput(message);
            int option;
            while (!int.TryParse(input, out option) || option > Enum.GetNames(typeof(T)).Length || option <= 0)
            {
                Console.WriteLine("Wrong Input");
                input =InputMethods.ReadInput("Insert a correct choice: ");
            }
            return option;
        }
    }
}
