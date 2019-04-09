using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;
using System.Data.Entity;

namespace PrivateSchoolManagerNew
{
    public enum UpdateAssignmentOptions
    {
        UpdateAll = 0,
        UpdateTitle,
        UpdateTitleAndDescription,
        UpdateTitleAndSubmissionDate,
        UpdateSubmissionDate,
        Cancel = 100
    }

    public static class AssignmentManager
    {
        public static void CreateAssignment(string title, string description, DateTime submissionDate, Course course)
        {
            Assignment assignment = new Assignment()
            {
                Title = title,
                Description = description,
                SubmissionDate = submissionDate,
                Course = course
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<Course>(assignment.Course).State = EntityState.Unchanged;
                db.Assignments.Add(assignment);
                db.SaveChanges();
            }
            MarkManager.AddMarkForNewAssignment(assignment.ID, course.ID);
        }

        public static void CreateAssignment(string title, string description, DateTime submissionDate, int courseID)
        {
            Assignment assignment = new Assignment()
            {
                Title = title,
                Description = description,
                SubmissionDate = submissionDate,
                Course = CourseManager.GetCourse(courseID)
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<Course>(assignment.Course).State = EntityState.Unchanged;
                db.Assignments.Add(assignment);
                db.SaveChanges();
            }
            MarkManager.AddMarkForNewAssignment(assignment.ID, courseID);
        }

        public static void CreateAssignment(string title, DateTime submissionDate, Course course)
        {
            Assignment assignment = new Assignment()
            {
                Title = title,
                SubmissionDate = submissionDate,
                Course = course
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<Course>(assignment.Course).State = EntityState.Unchanged;
                db.Assignments.Add(assignment);
                db.SaveChanges();
            }
            MarkManager.AddMarkForNewAssignment(assignment.ID, course.ID);
        }

        public static void CreateAssignment(string title, DateTime submissionDate, int courseID)
        {
            Assignment assignment = new Assignment()
            {
                Title = title,
                SubmissionDate = submissionDate,
                Course = CourseManager.GetCourse(courseID)
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<Course>(assignment.Course).State = EntityState.Unchanged;
                db.Assignments.Add(assignment);
                db.SaveChanges();
            }
            MarkManager.AddMarkForNewAssignment(assignment.ID, courseID);
        }

        public static List<Assignment> GetAllAssignments()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Assignments.Include(x => x.Course).ToList();
            }
        }

        public static List<Assignment> GetAllAssignments<T>(Func<Assignment, T> orderby)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Assignments.Include(x => x.Course).OrderBy(orderby).ToList();
            }
        }

        public static Assignment GetAssignment(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Assignments.Find(id);
            }
        }

        public static void DeleteAssignment(int id)
        {
            MarkManager.DeleteMarkFromDb(id, DeleteReason.Assignment);
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                db.Assignments.Remove(assignment);
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(int id, string title, string description, DateTime submissionDate)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                assignment.Title = title;
                assignment.Description = description;
                assignment.SubmissionDate = submissionDate;
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(int id, string title, DateTime submissionDate)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                assignment.Title = title;
                assignment.SubmissionDate = submissionDate;
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(int id, string title, string description)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                assignment.Title = title;
                assignment.Description = description;
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(int id, string title)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                assignment.Title = title;
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(int id, DateTime submissionDate)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return;
                }
                assignment.SubmissionDate = submissionDate;
                db.SaveChanges();
            }
        }

        public static bool UpdateCourseOfAssignment(int assignmentID, int newCourseID)
        {
            Course newCourse;
            using (SchoolContext db = new SchoolContext())
            {
                newCourse = db.Courses.Find(newCourseID);
            }
            if (newCourse == null)
            {
                return false;
            }
            MarkManager.DeleteMarkFromDb(assignmentID, DeleteReason.Assignment);
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(assignmentID);
                db.Entry<Course>(newCourse).State = EntityState.Unchanged;
                if (assignment == null)
                {
                    return false;
                }
                assignment.Course = newCourse;
                db.SaveChanges();                
            }
            MarkManager.AddMarkForNewAssignment(assignmentID, newCourseID);
            return true;
        }

        public static Course ReadCourseOfAssignment(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Assignment assignment = db.Assignments.Find(id);
                if (assignment == null)
                {
                    return null;
                }
                return assignment.Course;
            }
        }
    }
}
