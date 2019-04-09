using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;
using System.Data.Entity;
using Type = PrivateSchoolManagerNew.Models.Type;

namespace PrivateSchoolManagerNew
{
    public enum UpdateCourseOptions
    {
        UpdateAll = 0,
        UpdateTitle,
        UpdateTitleAndDates,
        UpdateTitleAndDatesAndStream,
        UpdateTitleAndDatesAndType,
        UpdateDatesAndStreamAndType,
        UpdateDates,
        UpdateDatesAndStream,
        UpdateDatesAndType,
        UpdateType,
        UpdateStream,
        UpdateStreamAndType,
        Cancel = 100
    }

    public class CourseManager
    {
        public static void CreateCourse(string title, DateTime startDate, DateTime endDate, Stream stream, Type type)
        {
            Course course = new Course()
            {
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                Stream = stream,
                Type = type
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        public static List<Course> GetAllCourses()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Courses.ToList();
            }
        }

        public static List<Course> GetAllCourses<T>(Func<Course, T> orderby)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Courses.OrderBy(orderby).ToList();
            }
        }

        public static Course GetCourse(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Courses.Find(id);
            }
        }

        public static void DeleteCourse(int id)
        {
            MarkManager.DeleteMarkFromDb(id, DeleteReason.Course);
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                db.Courses.Remove(course);
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, string title, DateTime startDate, DateTime endDate, Stream stream, Type type)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Title = title;
                course.StartDate = startDate;
                course.EndDate = endDate;
                course.Stream = stream;
                course.Type = type;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, string title)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Title = title;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, string title, DateTime startDate, DateTime endDate)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Title = title;
                course.StartDate = startDate;
                course.EndDate = endDate;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, string title, DateTime startDate, DateTime endDate, Stream stream)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Title = title;
                course.StartDate = startDate;
                course.EndDate = endDate;
                course.Stream = stream;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, string title, DateTime startDate, DateTime endDate, Type type)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Title = title;
                course.StartDate = startDate;
                course.EndDate = endDate;
                course.Type = type;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, DateTime startDate, DateTime endDate, Stream stream, Type type)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.StartDate = startDate;
                course.EndDate = endDate;
                course.Stream = stream;
                course.Type = type;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id,  DateTime startDate, DateTime endDate)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.StartDate = startDate;
                course.EndDate = endDate;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, DateTime startDate, DateTime endDate, Stream stream)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.StartDate = startDate;
                course.EndDate = endDate;
                course.Stream = stream;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, DateTime startDate, DateTime endDate, Type type)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.StartDate = startDate;
                course.EndDate = endDate;
                course.Type = type;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, Stream stream)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Stream = stream;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, Type type)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Type = type;
                db.SaveChanges();
            }
        }

        public static void UpdateCourse(int id, Stream stream, Type type)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(id);
                if (course == null)
                {
                    return;
                }
                course.Stream = stream;
                course.Type = type;
                db.SaveChanges();
            }
        }

        public static List<Trainer> ReadTrainersOfCourse(int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(courseID);
                if (course == null)
                {
                    return null;
                }
                List<Trainer> tr = course.Trainers.ToList();
                return tr;
            }
        }

        public static List<Student> ReadStudentsOfCourse(int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(courseID);
                if (course == null)
                {
                    return null;
                }
                List<Student> st = course.Students.ToList();
                return st;
            }
        }

        public static List<Assignment> ReadAssignmentsOfCourse(int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Course course = db.Courses.Find(courseID);
                if (course == null)
                {
                    return null;
                }
                List<Assignment> assign = course.Assignments.ToList();
                return assign;
            }
        }
    }
}
