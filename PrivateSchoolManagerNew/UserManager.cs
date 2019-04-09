using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;

namespace PrivateSchoolManagerNew
{
    public static class UserManager
    {
        public static void AddUser(User user)
        {
            using (SchoolContext db = new SchoolContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static bool AddHeadMasterAccount(string username, string password)
        {
            User user = GetUser(username);
            if (user != null)
            {
                return false;
            }
            user = new User()
            {
                Username = username,
                Password = SecurePasswordHasher.Hash(password),
                Role = Role.HeadMaster
            };

            AddUser(user);
            return true;
        }

        public static bool AddStudentAccount(string username, string password, out User user)
        {
            user = GetUser(username);
            if (user != null)
            {
                return false;
            }
            user = new User()
            {
                Username = username,
                Password = SecurePasswordHasher.Hash(password),
                Role = Role.Student
            };

            AddUser(user);
            return true;
        }

        public static bool AddTrainerAccount(string username, string password, out User user)
        {
            user = GetUser(username);
            if (user != null)
            {
                return false;
            }
            user = new User()
            {
                Username = username,
                Password = SecurePasswordHasher.Hash(password),
                Role = Role.Trainer
            };

            AddUser(user);
            return true;
        }

        public static User GetUser(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Users.Find(id);
            }
        }

        public static User GetUser(string username)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Users.Where(x => x.Username == username).FirstOrDefault();
            }
        }

        public static List<User> GetAllUsers()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Users.ToList();
            }
        }

        public static List<User> GetAllHeadMasters()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Users.Where(x => x.Role == Role.HeadMaster).ToList();
            }
        }

        public static List<User> GetAllUsers<T>(Func<User, T> orderby)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Users.OrderBy(orderby).ToList();
            }
        }

        public static void DeleteUser(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return;
                }
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public static bool ChangePassword(int id, string oldPassword, string newPassword)
        {
            using (SchoolContext db = new SchoolContext())
            {
                User user = db.Users.Find(id);
                if (user != null && SecurePasswordHasher.CheckPassword(user.Password, oldPassword))
                {
                    user.Password = SecurePasswordHasher.Hash(newPassword);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool ChangeUsername(int id, string newUsername)
        {
            using (SchoolContext db = new SchoolContext())
            {
                User user = db.Users.Where(x => x.Username == newUsername).FirstOrDefault();
                if (user == null )
                {
                    user = db.Users.Find(id);
                    user.Username = newUsername;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
