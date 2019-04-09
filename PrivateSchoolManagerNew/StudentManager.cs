using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;
using System.Data.Entity;

namespace PrivateSchoolManagerNew
{
    public enum UpdateStudentOptions
    {
        UpdateAll = 0,
        UpdateName,
        UpdateDoBAndFees,
        UpdateFees,
        UpdateDoB,
        UpdateNameAndFees,
        UpdateNameAndDoB,
        Cancel = 100
    }

        public static class StudentManager
    {
        public static void CreateStudent(string firstName, string lastName, User user)
        {
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1900, 1, 1),
                TuitionFees = 0,
                User = user
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<User>(student.User).State = EntityState.Unchanged;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public static void CreateStudent(string firstName, string lastName, DateTime dob, decimal tuitionFees, User user)
        {
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                TuitionFees = tuitionFees,
                User = user
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<User>(student.User).State = EntityState.Unchanged;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public static void CreateStudent(string firstName, string lastName, decimal tuitionFees, User user)
        {
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = new DateTime(1900, 1, 1),
                TuitionFees = tuitionFees,
                User = user
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<User>(student.User).State = EntityState.Unchanged;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public static void CreateStudent(string firstName, string lastName, DateTime dob, User user)
        {
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                TuitionFees = 0,
                User = user
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<User>(student.User).State = EntityState.Unchanged;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public static List<Student> GetAllStudents()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Students.ToList();
            }
        }

        public static List<Student> GetAllStudents<T>(Func<Student, T> orderby)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Students.OrderBy(orderby).ToList();
            }
        }

        public static Student GetStudent(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Students.Find(id);
            }
        }

        public static void DeleteStudent(int id)
        {
            MarkManager.DeleteMarkFromDb(id, DeleteReason.Student);
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                db.Students.Remove(student);
                db.SaveChanges();
            }
            UserManager.DeleteUser(id);
        }

        public static void UpdateStudent(int id, string firstName, string lastName, DateTime dob, decimal tuitionFees)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                student.FirstName = firstName;
                student.LastName = lastName;
                student.DateOfBirth = dob;
                student.TuitionFees = tuitionFees;
                db.SaveChanges();
            }
        }

        public static void UpdateStudent(int id, string firstName, string lastName)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                student.FirstName = firstName;
                student.LastName = lastName;
                db.SaveChanges();
            }
        }

        public static void UpdateStudent(int id, DateTime dob, decimal tuitionFees)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                student.DateOfBirth = dob;
                student.TuitionFees = tuitionFees;
                db.SaveChanges();
            }
        }

        public static void UpdateStudent(int id, decimal tuitionFees)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                student.TuitionFees = tuitionFees;
                db.SaveChanges();
            }
        }

        public static void UpdateStudent(int id, DateTime dob)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                student.DateOfBirth = dob;
                db.SaveChanges();
            }
        }

        public static void UpdateStudent(int id, string firstName, string lastName, decimal tuitionFees)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                student.FirstName = firstName;
                student.LastName = lastName;
                student.TuitionFees = tuitionFees;
                db.SaveChanges();
            }
        }

        public static void UpdateStudent(int id, string firstName, string lastName, DateTime dob)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return;
                }
                student.FirstName = firstName;
                student.LastName = lastName;
                student.DateOfBirth = dob;
                db.SaveChanges();
            }
        }

        public static bool AddCourseToStudent(int studentID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentID);
                Course course = db.Courses.Find(courseID);
                if (student == null || course == null)
                {
                    return false;
                }
                Course cr = student.Courses.SingleOrDefault(x => x.ID == courseID);
                if (cr == null)
                {
                    student.Courses.Add(course);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool DeleteCourseFromStudent(int studentID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentID);
                Course course = db.Courses.Find(courseID);
                if (student == null || course == null)
                {
                    return false;
                }
                Course cr = student.Courses.SingleOrDefault(x => x.ID == courseID);
                if (cr != null)
                {
                    student.Courses.Remove(course);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool UpdateCourseFromStudent(int studentID, int deleteCourseID, int addCourseID)
        {
            return (DeleteCourseFromStudent(studentID, deleteCourseID) && AddCourseToStudent(studentID, addCourseID));
        }

        public static List<Course> ReadCoursesOfStudent(int studentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentID);
                if (student == null)
                {
                    return null;
                }
                List<Course> cr = student.Courses.ToList();
                return cr;
            }
        }

        public static List<Assignment> ReadAssignmnentsOfStudent(int studentID)
        {
            List<Assignment> assignments = new List<Assignment>();
            using (SchoolContext db = new SchoolContext())
            {
                Student student = db.Students.Find(studentID);
                if (student == null)
                {
                    return null;
                }
                List<Course> courses = ReadCoursesOfStudent(studentID);
                foreach (var course in courses)
                {
                    List<Assignment> assignments1 = CourseManager.ReadAssignmentsOfCourse(course.ID);
                    foreach (var assignment in assignments1)
                    {
                        assignments.Add(assignment);
                    }
                }
                return assignments;
            }
        }
    }
}



