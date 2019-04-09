using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;

namespace PrivateSchoolManagerNew
{
    public static class LoginMenu
    {
        public static void Login()
        {
            while (true)
            {
                bool correctLogin = false;
                Role role = new Role();
                string username = "";
                string password = "";
                int ID =0;
                do
                {
                    username = InputMethods.ReadInput("Insert your username or write exit to close the app: ");
                    if (username == "exit")
                    {
                        return;
                    }
                    password = InputMethods.ReadInput("Insert your password: ");
                    //password = password.GetHashCode().ToString();
                    using (SchoolContext db = new SchoolContext())
                    {
                        User user = db.Users.Where(x => x.Username == username).FirstOrDefault();
                        //string savedPasswordHash = user.Password;
                        if (user != null && SecurePasswordHasher.CheckPassword(user.Password, password))
                        {
                            role = user.Role;
                            correctLogin = true;
                            ID = user.ID;
                        }
                    }
                } while (!correctLogin);
                
                switch (role)
                {
                    case Role.Student:
                        StudentMenu.Student(ID);
                        break;
                    case Role.Trainer:
                        TrainerMenu.Trainer(ID);
                        break;
                    case Role.HeadMaster:
                        HeadMasterMenu.HeadMaster(ID);
                        break;
                }
            }           

        }
    }
}
