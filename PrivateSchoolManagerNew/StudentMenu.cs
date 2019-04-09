using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;

namespace PrivateSchoolManagerNew
{
    public enum StudentMenuOptions
    {
        DisplayOptions = 0,
        ChangeUsername,
        ChangePassword,
        ViewYourCourses,
        EnrollToCourse,
        DailySchedule,
        ViewSubmissionDateOfAssignmentsPerCourse,
        SubmitAssignment,
        ViewYourAssignments,
        ViewYourMarks,
        LogOut = 100
    }

    public class StudentMenu
    {
        public static void DisplayMenuOptions()
        {
            Console.WriteLine($"{0,3}. Display Options");
            Console.WriteLine($"{1,3}. Change Username");
            Console.WriteLine($"{2,3}. Change Password");
            Console.WriteLine($"{3,3}. View your Courses");
            Console.WriteLine($"{4,3}. Enroll to new Course");
            Console.WriteLine($"{5,3}. View Schedule in a certain day");
            Console.WriteLine($"{6,3}. View Submission Date of Assignments Per Course");
            Console.WriteLine($"{7,3}. Submit Assignment");
            Console.WriteLine($"{8,3}. View your Assignments");
            Console.WriteLine($"{9,3}. View your Marks");
            Console.WriteLine($"{100,3}. Log out");
        }

        public static void ViewYourCourses(int id)
        {
            List<Course> courses = StudentManager.ReadCoursesOfStudent(id);
            if (courses.Count == 0)
            {
                Console.WriteLine("You are not enrolled to any course");
                return;
            }
            Console.WriteLine("You are enrolled in the following courses:\n");
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }            
        }

        public static void ViewYourAssignments(int id)
        {
            List<Assignment> assignments = StudentManager.ReadAssignmnentsOfStudent(id);
            if (assignments.Count == 0)
            {
                Console.WriteLine("You don\'t have any assignment to submit");
                return;
            }
            Console.WriteLine("Your asignments are:\n");
            foreach (var assignment in assignments)
            {
                Console.WriteLine(assignment);
            }
        }

        public static void EnrollToCourse(int id)
        {
            ViewYourCourses(id);
            int courseID = InputMethods.ReadID("course", "to enroll into");
            if (!StudentManager.AddCourseToStudent(id, courseID))
            {
                Console.WriteLine($"It failed to enroll into {courseID} course");
                return;
            }
            MarkManager.AddMarkForNewStudent(id, courseID);
        }

        public static void SubmitAssignment(int id)
        {
            ViewYourAssignments(id);
            int assignmentID = InputMethods.ReadID("assignment", "to submit it");
            if (!MarkManager.SubmitAssignment(id, assignmentID))
            {
                Console.WriteLine($"Submission failed!");
            }
        }

        public static void ViewSubmissionDateOfAssignmentsPerCourse(int id)
        {
            ViewYourCourses(id);
            int courseID = InputMethods.ReadID("course", "view its assignments");
            List<Assignment> assignments = CourseManager.ReadAssignmentsOfCourse(courseID);
            if (assignments.Count == 0)
            {
                Console.WriteLine("You don\'t have any assignment in this course");
                return;
            }
            Console.WriteLine("The submission date of your assignments in this course is:\n");
            foreach (var assignment in assignments)
            {
                Console.WriteLine(assignment.ShowSubmissionDate());
            }
        }

        public static void ViewDailySchedule(int studentID)
        {            
            List<Course> courses = StudentManager.ReadCoursesOfStudent(studentID);
            if (courses.Count == 0)
            {
                Console.WriteLine("You are not enrolled to any course");
                return;
            }
            DateTime date = InputMethods.ReadDate("Insert date to view its daily schedule: ");
            foreach (var course in courses)
            {
                if (course.StartDate < date && course.EndDate > date)
                {
                    Console.WriteLine(course.ToStringForDailySchedule());
                }
            }
        }

        public static void ViewYourMakrs(int studentID)
        {
            List<string> marks = MarkManager.ViewMarks(studentID);
            if (marks == null)
            {
                Console.WriteLine("You don\'t have any ssignment");
                return;
            }
            foreach (var mark in marks)
            {
                Console.WriteLine(mark);
            }
        }

        public static void Student(int id)
        {
            StudentMenuOptions option = new StudentMenuOptions();
            Console.WriteLine("\nUsing this program, you have the following options:");
            DisplayMenuOptions();
            bool exit = false;
            do
            {
                option = (StudentMenuOptions)GenericEnum.InsertOption<StudentMenuOptions>();
                switch (option)
                {
                    case StudentMenuOptions.DisplayOptions:
                        DisplayMenuOptions();
                        break;
                    case StudentMenuOptions.ChangeUsername:
                        HeadMasterMenu.ChangeUsername(id);
                        break;
                    case StudentMenuOptions.ChangePassword:
                        HeadMasterMenu.ChangePassword(id);
                        break;
                    case StudentMenuOptions.ViewYourCourses:
                        ViewYourCourses(id);
                        break;
                    case StudentMenuOptions.EnrollToCourse:
                        EnrollToCourse(id);
                        break;
                    case StudentMenuOptions.DailySchedule:
                        ViewDailySchedule(id);
                        break;
                    case StudentMenuOptions.ViewSubmissionDateOfAssignmentsPerCourse:
                        ViewSubmissionDateOfAssignmentsPerCourse(id);
                        break;
                    case StudentMenuOptions.SubmitAssignment:
                        SubmitAssignment(id);
                        break;
                    case StudentMenuOptions.ViewYourAssignments:
                        ViewYourAssignments(id);
                        break;
                    case StudentMenuOptions.ViewYourMarks:
                        ViewYourMakrs(id);
                        break;
                    case StudentMenuOptions.LogOut:
                        exit = true;
                        Console.WriteLine("\nLogged out.\n");
                        break;
                }
            } while (!exit);
        }
    }
}
