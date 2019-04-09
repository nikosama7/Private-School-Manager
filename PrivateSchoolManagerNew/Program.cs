using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;

namespace PrivateSchoolManagerNew
{
    internal class Program
    {
        internal static void ShowLogo()
        {
            Console.WriteLine("\n *************** *************** **************** *************** *************** *************** ");
            Console.WriteLine("* ************* * ************* | Private School Data Manager |* * ************* * ************* *");
            Console.WriteLine("** *********** *** *********** *------------------------------- *** *********** *** *********** **");
            Console.WriteLine("*** ********* ***** ********* ***** ********** ***** ********* ***** ********* ***** ********* ***");
            Console.WriteLine("**** ******* ******* ******* **| Created by Nikolaos Amartolos |***** ******* ******* ******* ****");
            Console.WriteLine("***** ***** ********* ***** ***---------------------------------****** ***** ********* ***** *****");
            Console.WriteLine("****** *** *********** *** ************ *** *********** *** *********** *** *********** *** ******");
            Console.WriteLine("******* * ************* * *************| Version: 2.0.2 |* ************* * ************* * *******");
            Console.WriteLine("******** *************** **************------------------ *************** *************** ********\n");
        }

        static void Main(string[] args)
        {
            ShowLogo();

            DatabaseGenerator.GeneratingUsers();

            LoginMenu.Login();

            ShowLogo();
            Console.WriteLine("\nPress any key to close the console window.");
            Console.ReadKey();
        }
    }
}
