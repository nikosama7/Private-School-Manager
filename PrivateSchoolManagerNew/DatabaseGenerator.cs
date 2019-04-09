using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using PrivateSchoolManagerNew.Models;

namespace PrivateSchoolManagerNew
{
    public class DatabaseGenerator
    {
        public static void GeneratingUsers()
        {
            int i;
            using (SchoolContext db = new SchoolContext())
            {
                i = db.Users.ToList().Count();
            }

            if (i == 0)
            {
                Console.Write("Creating Database...");
                UserManager.AddHeadMasterAccount("admin", "admin1234");
                UserManager.AddHeadMasterAccount("admin2", "admin0000");

                Console.Write("...");

                bool result = UserManager.AddStudentAccount("sploumis", "sploumis00", out User user);
                if (result)
                {
                    StudentManager.CreateStudent("Sotiris", "Ploumis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("mparaskevaidis", "marios1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Marios", "Paraskevaidis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("vgeorgillas", "vasilis1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Vasilis", "Georgilas", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("nikosama", "nikosama7", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Nikolaos", "Amartolos", new DateTime(1992, 9, 14), 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("billy", "billy1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Vasileios", "Tsagliotis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("akatsiaounis", "thano1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Athanasios", "Katsiaounis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("pskiadas", "yuri1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Panagiotis", "Skiadas", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("nkerantzakis", "kenza1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Nikos", "Kerantzakis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("mpittalis", "michalis1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Michalis", "Pittalis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("calexakis", "kris1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Christos", "Alexakis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("dperperidis", "perperidis1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Dimitrios", "Perperidis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("gdiakatos", "makis1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Gerasimos", "Diakatos", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("pandreadis", "petros1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Petros", "Andreadis", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("spattas", "stratos1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Stratos", "Pattas", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("echoutouriadi", "elina1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Elina", "Choutouriadi", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("akoulouras", "cwtabtab", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Anastasios", "Koulouras", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("kmichopoulos", "michop1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Konstantinos", "Michopoulos", 2500.0m, user);
                }
                result = UserManager.AddStudentAccount("nefthyvoulis", "efthyn1234", out user);
                if (result)
                {
                    StudentManager.CreateStudent("Nikolaos", "Efthyvoulis", 2500.0m, user);
                }

                Console.Write("...");

                result = UserManager.AddTrainerAccount("vyvasil", "vasil1234", out user);
                if (result)
                {
                    TrainerManager.CreateTrainer("Vyron", "Vasiliadis", user);
                }
                result = UserManager.AddTrainerAccount("ipplos", "ipplos1234", out user);
                if (result)
                {
                    TrainerManager.CreateTrainer("Ioannis", "Panagopoulos", user);
                }
                result = UserManager.AddTrainerAccount("mnikol", "nikolaid1s", out user);
                if (result)
                {
                    TrainerManager.CreateTrainer("Michalis", "Nikolaidis", user);
                }
                result = UserManager.AddTrainerAccount("pbozas", "panos1234", out user);
                if (result)
                {
                    TrainerManager.CreateTrainer("Panagiotis", "Bozas", user);
                }
                result = UserManager.AddTrainerAccount("gpaspar", "paspar1234", out user);
                if (result)
                {
                    TrainerManager.CreateTrainer("Georgios", "Pasparakis", user);
                }

                Console.Write("...");

                CourseManager.CreateCourse("ECDL Computing", new DateTime(2019, 02, 04), new DateTime(2019, 2, 7), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_1 Software Design & Development", new DateTime(2019, 02, 08), new DateTime(2019, 2, 11), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_2 GiT", new DateTime(2019, 02, 25), new DateTime(2019, 2, 25), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_3 OOP", new DateTime(2019, 02, 12), new DateTime(2019, 2, 21), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_5 SQL", new DateTime(2019, 02, 26), new DateTime(2019, 3, 5), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_4 HTML", new DateTime(2019, 03, 06), new DateTime(2019, 3, 7), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_4 CSS", new DateTime(2019, 03, 08), new DateTime(2019, 3, 12), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_4 Javascript", new DateTime(2019, 03, 13), new DateTime(2019, 3, 15), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_6 Web Application Development", new DateTime(2019, 03, 18), new DateTime(2019, 3, 22), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_8 UI/UX", new DateTime(2019, 03, 26), new DateTime(2019, 3, 29), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_9 Scrum", new DateTime(2019, 04, 01), new DateTime(2019, 4, 4), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("FSD_7 Software Testing & Debugging", new DateTime(2019, 02, 22), new DateTime(2019, 2, 22), Stream.Csharp, Models.Type.Full);
                CourseManager.CreateCourse("ECDL Computing", new DateTime(2019, 02, 04), new DateTime(2019, 2, 8), Stream.Csharp, Models.Type.Part);
                CourseManager.CreateCourse("FSD_1 Software Design & Development", new DateTime(2019, 02, 11), new DateTime(2019, 2, 15), Stream.Csharp, Models.Type.Part);
                CourseManager.CreateCourse("ECDL Computing", new DateTime(2019, 02, 04), new DateTime(2019, 2, 7), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_1 Software Design & Development", new DateTime(2019, 02, 08), new DateTime(2019, 2, 11), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_2 GiT", new DateTime(2019, 02, 25), new DateTime(2019, 2, 25), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_3 OOP", new DateTime(2019, 02, 12), new DateTime(2019, 2, 21), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_5 SQL", new DateTime(2019, 02, 26), new DateTime(2019, 3, 5), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_4 HTML", new DateTime(2019, 03, 06), new DateTime(2019, 3, 7), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_4 CSS", new DateTime(2019, 03, 08), new DateTime(2019, 3, 12), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_4 Javascript", new DateTime(2019, 03, 13), new DateTime(2019, 3, 15), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_6 Web Application Development", new DateTime(2019, 03, 18), new DateTime(2019, 3, 22), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_8 UI/UX", new DateTime(2019, 03, 26), new DateTime(2019, 3, 29), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_9 Scrum", new DateTime(2019, 04, 01), new DateTime(2019, 4, 4), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("FSD_7 Software Testing & Debugging", new DateTime(2019, 02, 22), new DateTime(2019, 2, 22), Stream.Java, Models.Type.Full);
                CourseManager.CreateCourse("ECDL Computing", new DateTime(2019, 02, 04), new DateTime(2019, 2, 8), Stream.Java, Models.Type.Part);
                CourseManager.CreateCourse("FSD_1 Software Design & Development", new DateTime(2019, 02, 11), new DateTime(2019, 2, 15), Stream.Java, Models.Type.Part);

                Console.Write("...");

                TrainerManager.AddCourseToTrainer(20, 1);
                TrainerManager.AddCourseToTrainer(21, 3);
                TrainerManager.AddCourseToTrainer(22, 2);
                TrainerManager.AddCourseToTrainer(22, 4);
                TrainerManager.AddCourseToTrainer(20, 5);
                TrainerManager.AddCourseToTrainer(21, 6);
                TrainerManager.AddCourseToTrainer(23, 15);
                TrainerManager.AddCourseToTrainer(23, 16);
                TrainerManager.AddCourseToTrainer(24, 17);
                TrainerManager.AddCourseToTrainer(24, 18);
                TrainerManager.AddCourseToTrainer(21, 24);
                TrainerManager.AddCourseToTrainer(24, 20);

                Console.Write("...");

                StudentManager.AddCourseToStudent(3, 1);
                StudentManager.AddCourseToStudent(4, 1);
                StudentManager.AddCourseToStudent(5, 1);
                StudentManager.AddCourseToStudent(6, 1);
                StudentManager.AddCourseToStudent(7, 1);
                StudentManager.AddCourseToStudent(8, 1);
                StudentManager.AddCourseToStudent(9, 1);
                StudentManager.AddCourseToStudent(10, 1);
                StudentManager.AddCourseToStudent(11, 15);
                StudentManager.AddCourseToStudent(12, 15);
                StudentManager.AddCourseToStudent(13, 15);
                StudentManager.AddCourseToStudent(14, 15);
                StudentManager.AddCourseToStudent(15, 15);
                StudentManager.AddCourseToStudent(16, 15);
                StudentManager.AddCourseToStudent(17, 15);
                StudentManager.AddCourseToStudent(18, 13);
                StudentManager.AddCourseToStudent(19, 13);
                StudentManager.AddCourseToStudent(3, 4);
                StudentManager.AddCourseToStudent(4, 4);
                StudentManager.AddCourseToStudent(5, 4);
                StudentManager.AddCourseToStudent(6, 4);
                StudentManager.AddCourseToStudent(7, 4);
                StudentManager.AddCourseToStudent(8, 4);
                StudentManager.AddCourseToStudent(9, 4);
                StudentManager.AddCourseToStudent(10, 4);
                StudentManager.AddCourseToStudent(11, 18);
                StudentManager.AddCourseToStudent(12, 18);
                StudentManager.AddCourseToStudent(13, 18);
                StudentManager.AddCourseToStudent(14, 18);
                StudentManager.AddCourseToStudent(15, 18);
                StudentManager.AddCourseToStudent(16, 18);
                StudentManager.AddCourseToStudent(17, 18);
                StudentManager.AddCourseToStudent(18, 14);
                StudentManager.AddCourseToStudent(3, 7);
                StudentManager.AddCourseToStudent(4, 7);
                StudentManager.AddCourseToStudent(5, 7);
                StudentManager.AddCourseToStudent(6, 7);
                StudentManager.AddCourseToStudent(7, 7);
                StudentManager.AddCourseToStudent(8, 7);
                StudentManager.AddCourseToStudent(9, 7);
                StudentManager.AddCourseToStudent(10, 7);
                StudentManager.AddCourseToStudent(11, 21);
                StudentManager.AddCourseToStudent(12, 21);
                StudentManager.AddCourseToStudent(13, 21);
                StudentManager.AddCourseToStudent(14, 21);
                StudentManager.AddCourseToStudent(15, 21);
                StudentManager.AddCourseToStudent(16, 21);
                StudentManager.AddCourseToStudent(17, 21);
                StudentManager.AddCourseToStudent(3, 8);
                StudentManager.AddCourseToStudent(4, 8);
                StudentManager.AddCourseToStudent(5, 8);
                StudentManager.AddCourseToStudent(6, 8);
                StudentManager.AddCourseToStudent(7, 8);
                StudentManager.AddCourseToStudent(8, 8);
                StudentManager.AddCourseToStudent(9, 8);
                StudentManager.AddCourseToStudent(10, 8);

                Console.Write("...");

                AssignmentManager.CreateAssignment("Assignment 1", new DateTime(2019, 2, 22, 23, 59, 59), 4);
                AssignmentManager.CreateAssignment("Assignment 2", new DateTime(2019, 3, 5, 23, 59, 59), 5);
                AssignmentManager.CreateAssignment("Assignment 3", new DateTime(2019, 3, 15, 23, 59, 59), 7);
                AssignmentManager.CreateAssignment("Individual Project", new DateTime(2019, 3, 18, 23, 59, 59), 8);
                AssignmentManager.CreateAssignment("Assignment 4", new DateTime(2019, 4, 3, 23, 59, 59), 9);
                AssignmentManager.CreateAssignment("Assignment 1", new DateTime(2019, 2, 22, 23, 59, 59), 18);
                AssignmentManager.CreateAssignment("Assignment 2", new DateTime(2019, 3, 5, 23, 59, 59), 19);
                AssignmentManager.CreateAssignment("Assignment 3", new DateTime(2019, 3, 15, 23, 59, 59), 21);
                AssignmentManager.CreateAssignment("Individual Project", new DateTime(2019, 3, 18, 23, 59, 59), 22);
                AssignmentManager.CreateAssignment("Assignment 4", new DateTime(2019, 4, 3, 23, 59, 59), 23);

                Console.Write("...\n");

                //using (SchoolContext db = new SchoolContext())
                //{
                //    List<Course> courses = db.Courses.ToList();
                //    foreach (var course in courses)
                //    {
                //        List<Student> students = course.Students.ToList();
                //        List<Assignment> assignments = course.Assignments.ToList();
                //        foreach (var student in students)
                //        {
                //            foreach (var assignment in assignments)
                //            {
                //                MarkManager.AddMarkToDb(student.ID, assignment.ID);
                //            }
                //        }
                //    }

                //}

                Console.WriteLine("Ready for use!\n");
            }            
        }
    }
}

