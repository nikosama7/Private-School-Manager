using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;
using System.Data.Entity;

namespace PrivateSchoolManagerNew
{
    public enum UpdateTrainerOptions
    {
        UpdateAll = 0,
        UpdateName,
        UpdateSubject,
        Cancel = 100
    }

    public static class TrainerManager
    {
        public static void CreateTrainer(string firstName, string lastName, User user)
        {
            Trainer trainer = new Trainer()
            {
                FirstName = firstName,
                LastName = lastName,
                User = user
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<User>(trainer.User).State = EntityState.Unchanged;
                db.Trainers.Add(trainer);
                db.SaveChanges();
            }
        }

        public static void CreateTrainer(string firstName, string lastName, string subject, User user)
        {
            Trainer trainer = new Trainer()
            {
                FirstName = firstName,
                LastName = lastName,
                Subject = subject,
                User = user
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<User>(trainer.User).State = EntityState.Unchanged;
                db.Trainers.Add(trainer);
                db.SaveChanges();
            }
        }

        public static List<Trainer> GetAllTrainers()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Trainers.ToList();
            }
        }

        public static List<Trainer> GetAllTrainers<T>(Func<Trainer, T> orderby)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Trainers.OrderBy(orderby).ToList();
            }
        }

        public static Trainer GetTrainer(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Trainers.Find(id);
            }
        }

        public static void DeleteTrainer(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(id);
                if (trainer == null)
                {
                    return;
                }
                db.Trainers.Remove(trainer);
                db.SaveChanges();
            }
            UserManager.DeleteUser(id);
        }

        public static void UpdateTrainer(int id, string firstName, string lastName, string subject)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(id);
                if (trainer == null)
                {
                    return;
                }
                trainer.FirstName = firstName;
                trainer.LastName = lastName;
                trainer.Subject = subject;
                db.SaveChanges();
            }
        }

        public static void UpdateTrainer(int id, string firstName, string lastName)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(id);
                if (trainer == null)
                {
                    return;
                }
                trainer.FirstName = firstName;
                trainer.LastName = lastName;
                db.SaveChanges();
            }
        }

        public static void UpdateTrainer(int id, string subject)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(id);
                if (trainer == null)
                {
                    return;
                }
                trainer.Subject = subject;
                db.SaveChanges();
            }
        }

        public static bool AddCourseToTrainer(int trainerID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                Course course = db.Courses.Find(courseID);
                if (trainer == null || course == null)
                {
                    return false;
                }
                Course cr = trainer.Courses.SingleOrDefault(x => x.ID == courseID);
                if (cr == null)
                {
                    trainer.Courses.Add(course);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool DeleteCourseFromTrainer(int trainerID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                Course course = db.Courses.Find(courseID);
                if (trainer == null || course == null)
                {
                    return false;
                }
                Course cr = trainer.Courses.SingleOrDefault(x => x.ID == courseID);
                if (cr != null)
                {
                    trainer.Courses.Remove(course);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool UpdateCourseFromTrainer(int trainerID, int deleteCourseID, int addCourseID)
        {
            return (DeleteCourseFromTrainer(trainerID, deleteCourseID) && AddCourseToTrainer(trainerID, addCourseID));
        }

        public static List<Course> ReadCoursesOfTrainer(int trainerID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                if (trainer == null )
                {
                    return null;
                }
                List<Course> cr = trainer.Courses.ToList();
                return cr;
            }
        }
    }
}
