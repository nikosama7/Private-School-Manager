using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;

namespace PrivateSchoolManagerNew
{
    public enum TrainerMenuOptions
    {
        DisplayOptions = 0,
        ChangeUsername,
        ChangePassword,
        ViewYourCourses,
        ViewStudentsPerCourse,
        ViewAssignmentsPerStudentPerCourse,
        MarkAssignments,

        LogOut = 100
    }

    public class TrainerMenu
    {
        public static void DisplayMenuOptions()
        {
            Console.WriteLine($"{0,3}. Display Options");
            Console.WriteLine($"{1,3}. Change Username");
            Console.WriteLine($"{2,3}. Change Password");
            Console.WriteLine($"{3,3}. View your Courses");
            Console.WriteLine($"{4,3}. View Students per Course");
            Console.WriteLine($"{5,3}. View Assignments per Student per Course");
            Console.WriteLine($"{6,3}. Mark Assignments");
            Console.WriteLine($"{100,3}. Log out");
        }

        public static bool ViewYourCourses(int id)
        {
            List<Course> courses = TrainerManager.ReadCoursesOfTrainer(id);
            if (courses.Count == 0)
            {
                Console.WriteLine("You are not enrolled to any course");
                return false;
            }
            Console.WriteLine("You are enrolled in the following courses:\n");
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }
            return true;
        }

        public static void ViewAssignmentsPerStudentPerCourse(int id)
        {
            if (!ViewStudentsPerCourse(id, out int courseID))
            {
                return;
            }
            using (SchoolContext db = new SchoolContext())
            {
                List<Assignment> assignments = db.Courses.Find(courseID).Assignments.ToList();
                if (assignments.Count() == 0)
                {
                    Console.WriteLine("They don\'t have any assignments in this course.");
                    return;
                }
                Console.WriteLine("Their assignmnets in this course are:");
                foreach (var assignment in assignments)
                {
                    Console.WriteLine(assignment);
                }
            }
        }

        public static void MarkAssignments(int id)
        {
            if (!ViewStudentsPerCourse(id, out int courseID))
            {
                return;
            }
            int studentID = InputMethods.ReadID("student", "mark its assignments");
            List<Assignment> assignments;
            using (SchoolContext db = new SchoolContext())
            {
                assignments = db.Courses.Find(courseID).Assignments.ToList();
            }
            if (assignments.Count() == 0)
            {
                Console.WriteLine("They don\'t have any assignments in this course.");
                return;
            }
            Console.WriteLine("Their assignmnets in this course are:");
            foreach (var assignment in assignments)
            {
                Console.WriteLine(assignment);
            }
            int assignmentID = InputMethods.ReadID("asingment", "mark it");
            decimal totalMark = InputMethods.ReadMarks("Insert total mark: ");
            decimal oralMark = InputMethods.ReadMarks("Insert oral mark: ");
            MarkManager.AddMark(studentID, assignmentID, totalMark, oralMark);
        }

        public static bool ViewStudentsPerCourse(int id, out int courseID)
        {
            if (ViewYourCourses(id))
            {
                courseID = InputMethods.ReadID("course", "to view its student");
                List<Student> students = CourseManager.ReadStudentsOfCourse(courseID);
                if (students.Count == 0)
                {
                    Console.WriteLine("There are not students enrolled to this course");
                    return false;
                }
                Console.WriteLine("Your students in this course are:\n");
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
                return true;
            }
            courseID = -1;
            return false;
        }

        public static void Trainer(int id)
        {
            TrainerMenuOptions option = new TrainerMenuOptions();
            Console.WriteLine("\nUsing this program, you have the following options:");
            DisplayMenuOptions();
            bool exit = false;
            do
            {
                option = (TrainerMenuOptions)GenericEnum.InsertOption<TrainerMenuOptions>();
                switch (option)
                {
                    case TrainerMenuOptions.DisplayOptions:
                        DisplayMenuOptions();
                        break;
                    case TrainerMenuOptions.ChangeUsername:
                        HeadMasterMenu.ChangeUsername(id);
                        break;
                    case TrainerMenuOptions.ChangePassword:
                        HeadMasterMenu.ChangePassword(id);
                        break;
                    case TrainerMenuOptions.ViewYourCourses:
                        ViewYourCourses(id);
                        break;
                    case TrainerMenuOptions.ViewStudentsPerCourse:
                        ViewStudentsPerCourse(id, out int courseID);
                        break;
                    case TrainerMenuOptions.ViewAssignmentsPerStudentPerCourse:
                        ViewAssignmentsPerStudentPerCourse(id);
                        break;
                    case TrainerMenuOptions.MarkAssignments:
                        MarkAssignments(id);
                        break;
                    case TrainerMenuOptions.LogOut:
                        exit = true;
                        Console.WriteLine("\nLogged out.\n");
                        break;
                }
            } while (!exit);
        }
    }
}
