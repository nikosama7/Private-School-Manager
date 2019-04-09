using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;
using System.Data.Entity;

namespace PrivateSchoolManagerNew
{
    public enum DeleteReason
    {
        Course,
        Student,
        Assignment
    }


    public class MarkManager
    {
        public static bool AddMarkToDb(int studentID, int assignmentID)
        {
            Assignment assignment = AssignmentManager.GetAssignment(assignmentID);
            using (SchoolContext db = new SchoolContext())
            {
                db.Entry<Assignment>(assignment).State = EntityState.Unchanged;
                Course course = assignment.Course;
                if (course.Students.Where(x => x.ID == studentID).FirstOrDefault() == null)
                {
                    return false;
                }
            }                

            Mark mark = new Mark()
            {
                AssignmentID = assignmentID,
                StudentID = studentID,
                OralMark = 0.0m,
                TotalMark = 0.0m,
                Submitted = false
            };

            using (SchoolContext db = new SchoolContext())
            {
                db.Marks.Add(mark);
                db.SaveChanges();
            }
            return true;
        }

        public static void DeleteMarkFromDb(int ID, DeleteReason reason)
        {
            List<Mark> marks;
            using (SchoolContext db = new SchoolContext())
            {
                switch (reason)
                {
                    case DeleteReason.Course:
                        List<Assignment> assignments = CourseManager.ReadAssignmentsOfCourse(ID);
                        foreach (var assignment in assignments)
                        {
                            marks = db.Marks.Where(x => x.AssignmentID == assignment.ID).ToList();
                            foreach (var mark in marks)
                            {
                                db.Marks.Remove(mark);
                                db.SaveChanges();
                            }
                        }
                        return;
                    case DeleteReason.Student:
                        marks = db.Marks.Where(x => x.StudentID == ID).ToList();
                        foreach (var mark in marks)
                        {
                            db.Marks.Remove(mark);
                            db.SaveChanges();
                        }
                        return;
                    case DeleteReason.Assignment:
                        marks = db.Marks.Where(x => x.AssignmentID == ID).ToList();
                        foreach (var mark in marks)
                        {
                            db.Marks.Remove(mark);
                            db.SaveChanges();
                        }
                        return;
                }
            }
        }

        public static void ChangeMarkFromDbForStudentChange(int studentID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                List<Assignment> assignments = CourseManager.ReadAssignmentsOfCourse(courseID);
                foreach (var assignment in assignments)
                {
                    Mark mark = db.Marks.Find(studentID, assignment.ID);
                    db.Marks.Remove(mark);
                    db.SaveChanges();
                }
            }
        }

        public static void ChangeMarkFromDb(int studentID, int courseID, int newCourseID)
        {
            ChangeMarkFromDbForStudentChange(studentID, courseID);
            AddMarkForNewStudent(studentID, newCourseID);
        }

        public static void ChangeMarkFromDbAssignment(int assignmentID, int newCourseID)
        {
            DeleteMarkFromDb(assignmentID, DeleteReason.Assignment);
            AddMarkForNewAssignment(assignmentID, newCourseID);
        }

        public static bool AddMark(int studentID, int assignmentID, decimal totalMark, decimal oralMark)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Mark mark = db.Marks.Find(studentID, assignmentID);
                if (mark == null || !mark.Submitted)
                {
                    Console.WriteLine("No assignment has been submitted.");
                    return false;
                }
                mark.OralMark = oralMark;
                mark.TotalMark = totalMark;
                db.SaveChanges();
            }
            return true;
        }

        public static bool AddMarkForNewStudent(int studentID, int courseID)
        {
            bool result = true;
            List<Assignment> assignments = CourseManager.ReadAssignmentsOfCourse(courseID);
            foreach (var assignment in assignments)
            {
                if(!AddMarkToDb(studentID, assignment.ID))
                {
                    result = false;
                }
            }
            return result;
        }

        public static bool AddMarkForNewAssignment(int assignmentID, int courseID)
        {
            bool result = true;
            List<Student> students;
            using (SchoolContext db = new SchoolContext())
            {
                students = CourseManager.ReadStudentsOfCourse(courseID);
            }
            foreach (var student in students)
            {
                if (!AddMarkToDb(student.ID, assignmentID))
                {
                    result = false;
                }
            }
            return result;
        }

        public static bool SubmitAssignment(int studentID, int assignmentID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Mark mark = db.Marks.Find(studentID, assignmentID);
                if (mark == null)
                {
                    return false;
                }
                mark.Submitted = true;
                mark.SubmittedDate = DateTime.Now;
                db.SaveChanges();
            }
            return true;
        }

        public static List<string> ViewMarks(int studentID)
        {
            List<Mark> marks = new List<Mark>();
            using (SchoolContext db = new SchoolContext())
            {
                marks = db.Marks.Where(x => x.StudentID == studentID).ToList();
                if (marks.Count == 0)
                {
                    return null;
                }
            }
            List<string> result = new List<string>();
            using (SchoolContext db = new SchoolContext())
            {                
                foreach (var mark in marks)
                {
                    Assignment assignment = db.Assignments.Find(mark.AssignmentID);
                    result.Add(mark.ToString(assignment));
                }
            }
            return result;
        }
    }
}
