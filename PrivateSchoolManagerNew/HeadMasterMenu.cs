using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchoolManagerNew.Models;

namespace PrivateSchoolManagerNew
{
    public enum HeadMasterMenuOptions
    {
        DisplayOptions = 0,
        InsertNewCourse,
        ViewListOfCourses,
        UpdateCourseInfos,
        DeleteCourse,
        InsertNewStudent,
        ViewListOfStudents,
        UpdateStudentInfos,
        DeleteStudent,
        InsertNewTrainer,
        ViewListOfTrainers,
        UpdateTrainerInfos,
        DeleteTrainer,
        InsertNewAssignment,
        ViewListOfAssignments,
        UpdateAssignmentInfos,
        DeleteAssignment,
        InsertStudentToCourse,
        DeleteStudentFromCourse,
        ViewStudentsPerCourse,
        ChangeCourseOfStudent,
        InsertTrainerToCourse,
        DeleteTrainerFromCourse,
        ViewTrainersPerCourse,
        ChangeCourseOfTrainer,
        InsertAssignmentToCourse,
        DeleteAssignmentFromCourse,
        ViewAssignmentsPerCourse,
        ChangeCourseOfAssignment,
        ViewHeadMasters,
        InsertNewHeadMaster,
        DeleteHeadMaster,
        ChangePassword,
        ChangeUsername,
        LogOut = 100
    }

    public class HeadMasterMenu
    {
        public static void DisplayMenuOptions()
        {
            Console.WriteLine($"{0,3}. Display Options");
            Console.WriteLine($"{1,3}. Insert new Course");
            Console.WriteLine($"{2,3}. View list of Courses");
            Console.WriteLine($"{3,3}. Update Course Infos");
            Console.WriteLine($"{4,3}. Delete Course");
            Console.WriteLine($"{5,3}. Insert new Student");
            Console.WriteLine($"{6,3}. View list of Students");
            Console.WriteLine($"{7,3}. Update Student Infos");
            Console.WriteLine($"{8,3}. Delete Student");
            Console.WriteLine($"{9,3}. Insert new Trainer");
            Console.WriteLine($"{10,3}. View list of Trainers");
            Console.WriteLine($"{11,3}. Update Trainer Infos");
            Console.WriteLine($"{12,3}. Delete Trainer");
            Console.WriteLine($"{13,3}. Insert new Assignment");
            Console.WriteLine($"{14,3}. View list of Assignments");
            Console.WriteLine($"{15,3}. Update Assignment Infos");
            Console.WriteLine($"{16,3}. Delete Assignment");
            Console.WriteLine($"{17,3}. Insert Student to Course");
            Console.WriteLine($"{18,3}. Delete Student from Course");
            Console.WriteLine($"{19,3}. View Students per Course");
            Console.WriteLine($"{20,3}. Change Course of Student");
            Console.WriteLine($"{21,3}. Insert Trainer to Course");
            Console.WriteLine($"{22,3}. Delete Trainer from Course");
            Console.WriteLine($"{23,3}. View Trainers per Course");
            Console.WriteLine($"{24,3}. Change Course of Trainer");
            Console.WriteLine($"{25,3}. Insert Assignment to Course");
            Console.WriteLine($"{26,3}. Delete Assignment from Course");
            Console.WriteLine($"{27,3}. View Assignments per Course");
            Console.WriteLine($"{28,3}. Change Course of Assignment");
            Console.WriteLine($"{29,3}. View Head Masters");
            Console.WriteLine($"{30,3}. Insert new Head Master");
            Console.WriteLine($"{31,3}. Delete Head Master");
            Console.WriteLine($"{32,3}. Change Password");
            Console.WriteLine($"{33,3}. Change Username");
            Console.WriteLine($"{100,3}. Log out");
        }

        public static void DisplayUpdateCourseOptions()
        {
            Console.WriteLine($"{0,3}. Update All");
            Console.WriteLine($"{1,3}. Update Title");
            Console.WriteLine($"{2,3}. Update Title, Start Date and End Date");
            Console.WriteLine($"{3,3}. Update Title, Start Date, End Date and Stream");
            Console.WriteLine($"{4,3}. Update Title, Start Date, End Date and Type");
            Console.WriteLine($"{5,3}. Update Start Date, End Date, Stream and Type");
            Console.WriteLine($"{6,3}. Update Start Date and End Date");
            Console.WriteLine($"{7,3}. Update Start Date, End Date and Stream");
            Console.WriteLine($"{8,3}. Update Start Date, End Date and Type");
            Console.WriteLine($"{9,3}. Update Type");
            Console.WriteLine($"{10,3}. Update Stream");
            Console.WriteLine($"{11,3}. Update Stream and Type");
            Console.WriteLine($"{100,3}. Back");
        }

        public static void DisplayStreamOptions()
        {
            for (int i = 1; i <= Enum.GetNames(typeof(Stream)).Length; i++)
            {
                Console.WriteLine($"{i,3:D} - {(Stream)i}");
            }
        }

        public static void DisplayTypeOptions()
        {
            for (int i = 1; i <= Enum.GetNames(typeof(Models.Type)).Length; i++)
            {
                Console.WriteLine($"{i,3:D} - {(Models.Type)i}");
            }
        }

        public static void DisplayUpdateStudentOptions()
        {
            Console.WriteLine($"{0,3}. Update All");
            Console.WriteLine($"{1,3}. Update Name");
            Console.WriteLine($"{2,3}. Update Date of Birth and Tuition Fees");
            Console.WriteLine($"{3,3}. Update uition Fees");
            Console.WriteLine($"{4,3}. Update Date of Birth");
            Console.WriteLine($"{5,3}. Update Name and Tuition Fees");
            Console.WriteLine($"{6,3}. Update Name and Date of Birth");
            Console.WriteLine($"{100,3}. Back");
        }

        public static void DisplayUpdateTrainerOptions()
        {
            Console.WriteLine($"{0,3}. Update All");
            Console.WriteLine($"{1,3}. Update Name");
            Console.WriteLine($"{2,3}. Update Subject");
            Console.WriteLine($"{100,3}. Back");
        }
 
        public static void DisplayUpdateAssignmentOptions()
        {
            Console.WriteLine($"{0,3}. Update All");
            Console.WriteLine($"{1,3}. Update Title");
            Console.WriteLine($"{2,3}. Update Title and Description");
            Console.WriteLine($"{3,3}. Update Title and Submission Date");
            Console.WriteLine($"{4,3}. Update Submission Date");
            Console.WriteLine($"{100,3}. Back");
        }

        public static void InsertNewCourse()
        {
            string title = InputMethods.ReadInput("Insert the title of new course: ");
            DateTime startDate = InputMethods.ReadDate("Insert the start date of the course: ");
            DateTime endDate = InputMethods.ReadDate("Insert the end date of the course: ");
            DisplayStreamOptions();
            Stream stream = (Stream)GenericEnum.ReadStreamOrTypeOrRole<Stream>("Insert the Stream of course: ");
            DisplayTypeOptions();
            Models.Type type = (Models.Type)GenericEnum.ReadStreamOrTypeOrRole<Models.Type>("Insert the Type of course: ");
            CourseManager.CreateCourse(title, startDate, endDate, stream, type);
        }

        public static void ViewListOfCourses()
        {
            List<Course> courses = CourseManager.GetAllCourses();
            foreach (var c in courses)
            {
                Console.WriteLine(c);
            }
        }

        public static void UpdateCourseInfos()
        {
            ViewListOfCourses();
            int id = InputMethods.ReadID("course", "change");
            DisplayUpdateCourseOptions();
            Console.WriteLine("Choose what changes you want to do");
            UpdateCourseOptions option = (UpdateCourseOptions)GenericEnum.InsertOption<UpdateCourseOptions>();
            switch (option)
            {
                case UpdateCourseOptions.UpdateAll:
                    string title = InputMethods.ReadInput("Insert the new title of the course: ");
                    DateTime startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    DateTime endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    DisplayStreamOptions();
                    Stream stream = (Stream)GenericEnum.ReadStreamOrTypeOrRole<Stream>("Insert the Stream of course: ");
                    DisplayTypeOptions();
                    Models.Type type = (Models.Type)GenericEnum.ReadStreamOrTypeOrRole<Models.Type>("Insert the Type of course: ");
                    CourseManager.UpdateCourse(id, title, startDate, endDate, stream, type);
                    break;
                case UpdateCourseOptions.UpdateTitle:
                    title = InputMethods.ReadInput("Insert the new title of the course: ");
                    CourseManager.UpdateCourse(id, title);
                    break;
                case UpdateCourseOptions.UpdateTitleAndDates:
                    title = InputMethods.ReadInput("Insert the new title of the course: ");
                    startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    CourseManager.UpdateCourse(id, title, startDate, endDate);
                    break;
                case UpdateCourseOptions.UpdateTitleAndDatesAndStream:
                    title = InputMethods.ReadInput("Insert the new title of the course: ");
                    startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    DisplayStreamOptions();
                    stream = (Stream)GenericEnum.ReadStreamOrTypeOrRole<Stream>("Insert the Stream of course: ");
                    CourseManager.UpdateCourse(id, title, startDate, endDate, stream);
                    break;
                case UpdateCourseOptions.UpdateTitleAndDatesAndType:
                    title = InputMethods.ReadInput("Insert the new title of the course: ");
                    startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    DisplayTypeOptions();
                    type = (Models.Type)GenericEnum.ReadStreamOrTypeOrRole<Models.Type>("Insert the Type of course: ");
                    CourseManager.UpdateCourse(id, title, startDate, endDate, type);
                    break;
                case UpdateCourseOptions.UpdateDatesAndStreamAndType:
                    startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    DisplayStreamOptions();
                    stream = (Stream)GenericEnum.ReadStreamOrTypeOrRole<Stream>("Insert the Stream of course: ");
                    DisplayTypeOptions();
                    type = (Models.Type)GenericEnum.ReadStreamOrTypeOrRole<Models.Type>("Insert the Type of course: ");
                    CourseManager.UpdateCourse(id, startDate, endDate, stream, type);
                    break;
                case UpdateCourseOptions.UpdateDates:
                    startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    CourseManager.UpdateCourse(id, startDate, endDate);
                    break;
                case UpdateCourseOptions.UpdateDatesAndStream:
                    startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    DisplayStreamOptions();
                    stream = (Stream)GenericEnum.ReadStreamOrTypeOrRole<Stream>("Insert the Stream of course: ");
                    CourseManager.UpdateCourse(id, startDate, endDate, stream);
                    break;
                case UpdateCourseOptions.UpdateDatesAndType:
                    startDate = InputMethods.ReadDate("Insert the start date of the course: ");
                    endDate = InputMethods.ReadEndDate("Insert the end date of the course: ", startDate);
                    DisplayTypeOptions();
                    type = (Models.Type)GenericEnum.ReadStreamOrTypeOrRole<Models.Type>("Insert the Type of course: ");
                    CourseManager.UpdateCourse(id, startDate, endDate, type);
                    break;
                case UpdateCourseOptions.UpdateType:
                    DisplayTypeOptions();
                    type = (Models.Type)GenericEnum.ReadStreamOrTypeOrRole<Models.Type>("Insert the Type of course: ");
                    CourseManager.UpdateCourse(id, type);
                    break;
                case UpdateCourseOptions.UpdateStream:
                    DisplayStreamOptions();
                    stream = (Stream)GenericEnum.ReadStreamOrTypeOrRole<Stream>("Insert the Stream of course: ");
                    CourseManager.UpdateCourse(id, stream);
                    break;
                case UpdateCourseOptions.UpdateStreamAndType:
                    DisplayStreamOptions();
                    stream = (Stream)GenericEnum.ReadStreamOrTypeOrRole<Stream>("Insert the Stream of course: ");
                    DisplayTypeOptions();
                    type = (Models.Type)GenericEnum.ReadStreamOrTypeOrRole<Models.Type>("Insert the Type of course: ");
                    CourseManager.UpdateCourse(id, stream, type);
                    break;
                case UpdateCourseOptions.Cancel:
                    InputMethods.Cancel();
                    break;
            }
        }

        public static void DeleteCourse()
        {
            ViewListOfCourses();
            int id = InputMethods.ReadID("course", "delete");
            CourseManager.DeleteCourse(id);
        }

        public static void InsertNewStudent()
        {
            InputMethods.ReadFullName(out string firstName, out string lastName, "student");
            User user = new User();
            string username;
            string password;
            do
            {
                username = InputMethods.ReadInput("Insert username: ");
                password = InputMethods.ReadInput("Insert password: ");
            } while (!UserManager.AddStudentAccount(username, password, out user)); 
            StudentManager.CreateStudent(firstName, lastName, user);
        }

        public static void ViewListOfStudents()
        {
            List<Student> students = StudentManager.GetAllStudents();
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
        }

        public static void DeleteStudent()
        {
            ViewListOfStudents();
            int id = InputMethods.ReadID("student", "delete");
            StudentManager.DeleteStudent(id);
        }

        public static void UpdateStudentInfos()
        {
            ViewListOfStudents();
            int id = InputMethods.ReadID("student", "change");
            DisplayUpdateStudentOptions();
            Console.WriteLine("Choose what changes you want to do");
            UpdateStudentOptions option = (UpdateStudentOptions)GenericEnum.InsertOption<UpdateStudentOptions>();
            switch (option)
            {
                case UpdateStudentOptions.UpdateAll:
                    InputMethods.ReadFullName(out string firstName, out string lastName, "student");
                    DateTime dob = InputMethods.ReadDoB();
                    decimal fees = InputMethods.ReadFees();
                    StudentManager.UpdateStudent(id, firstName, lastName, dob, fees);
                    break;
                case UpdateStudentOptions.UpdateName:
                    InputMethods.ReadFullName(out firstName, out lastName, "student");
                    StudentManager.UpdateStudent(id, firstName, lastName);
                    break;
                case UpdateStudentOptions.UpdateDoBAndFees:
                    dob = InputMethods.ReadDoB();
                    fees = InputMethods.ReadFees();
                    StudentManager.UpdateStudent(id, dob, fees);
                    break;
                case UpdateStudentOptions.UpdateFees:
                    fees = InputMethods.ReadFees();
                    StudentManager.UpdateStudent(id, fees);
                    break;
                case UpdateStudentOptions.UpdateDoB:
                    dob = InputMethods.ReadDoB();
                    StudentManager.UpdateStudent(id, dob);
                    break;
                case UpdateStudentOptions.UpdateNameAndFees:
                    InputMethods.ReadFullName(out firstName, out lastName, "student");
                    fees = InputMethods.ReadFees();
                    StudentManager.UpdateStudent(id, firstName, lastName, fees);
                    break;
                case UpdateStudentOptions.UpdateNameAndDoB:
                    InputMethods.ReadFullName(out firstName, out lastName, "student");
                    dob = InputMethods.ReadDoB();
                    StudentManager.UpdateStudent(id, firstName, lastName, dob);
                    break;
                case UpdateStudentOptions.Cancel:
                    InputMethods.Cancel();
                    break;
            }
        }

        public static void InsertNewTrainer()
        {
            InputMethods.ReadFullName(out string firstName, out string lastName, "trainer");
            User user = new User();
            string username;
            string password;
            do
            {
                username = InputMethods.ReadInput("Insert username: ");
                password = InputMethods.ReadInput("Insert password: ");
            } while (!UserManager.AddTrainerAccount(username, password, out user));
            TrainerManager.CreateTrainer(firstName, lastName, user);
        }

        public static void ViewListOfTrainers()
        {
            List<Trainer> trainers = TrainerManager.GetAllTrainers();
            foreach (var tr in trainers)
            {
                Console.WriteLine(tr);
            }
        }

        public static void DeleteTrainer()
        {
            ViewListOfTrainers();
            int id = InputMethods.ReadID("trainer", "delete");
            TrainerManager.DeleteTrainer(id);
        }

        public static void UpdateTrainerInfos()
        {
            ViewListOfTrainers();
            int id = InputMethods.ReadID("trainer", "change");
            DisplayUpdateTrainerOptions();
            Console.WriteLine("Choose what changes you want to do");
            UpdateTrainerOptions option = (UpdateTrainerOptions)GenericEnum.InsertOption<UpdateTrainerOptions>();
            switch (option)
            {
                case UpdateTrainerOptions.UpdateAll:
                    InputMethods.ReadFullName(out string firstName, out string lastName, "trainer");
                    string subject = InputMethods.ReadInput("Insert a subject for the trainer: ");
                    TrainerManager.UpdateTrainer(id, firstName, lastName, subject);
                    break;
                case UpdateTrainerOptions.UpdateName:
                    InputMethods.ReadFullName(out firstName, out lastName, "trainer");
                    TrainerManager.UpdateTrainer(id, firstName, lastName);
                    break;
                case UpdateTrainerOptions.UpdateSubject:
                    subject = InputMethods.ReadInput("Insert a subject for the trainer: ");
                    TrainerManager.UpdateTrainer(id, subject);
                    break;
                case UpdateTrainerOptions.Cancel:
                    InputMethods.Cancel();
                    break;
            }
        }

        public static void InsertNewAssignment()
        {
            string title = InputMethods.ReadInput("Insert the title of new assignment: ");
            DateTime submissionDate = InputMethods.ReadDate("Insert the submission date and time of the new assignment: ");
            ViewListOfCourses();
            int courseID = InputMethods.ReadID("course", "to add it an assignment");
            AssignmentManager.CreateAssignment(title, submissionDate, courseID);
        }

        public static void ViewListOfAssignments()
        {
            List<Assignment> assignments = AssignmentManager.GetAllAssignments();
            foreach (var assign in assignments)
            {
                Console.WriteLine(assign);
            }
        }

        public static void UpdateAssignmentInfos()
        {
            ViewListOfAssignments();
            int id = InputMethods.ReadID("assignment", "change");
            DisplayUpdateAssignmentOptions();
            Console.WriteLine("Choose what changes you want to do");
            UpdateAssignmentOptions option = (UpdateAssignmentOptions)GenericEnum.InsertOption<UpdateAssignmentOptions>();
            switch (option)
            {
                case UpdateAssignmentOptions.UpdateAll:
                    string title = InputMethods.ReadInput("Insert the new title of the assignment: ");
                    string description = InputMethods.ReadInput("Insert the new description of the assignment: ");
                    DateTime submissionDate = InputMethods.ReadDate("Insert the new submission date and time of the assignment: ");
                    AssignmentManager.UpdateAssignment(id, title, description, submissionDate);
                    break;
                case UpdateAssignmentOptions.UpdateTitle:
                    title = InputMethods.ReadInput("Insert the new title of the assignment: ");
                    AssignmentManager.UpdateAssignment(id, title);
                    break;
                case UpdateAssignmentOptions.UpdateTitleAndDescription:
                    title = InputMethods.ReadInput("Insert the new title of the assignment: ");
                    description = InputMethods.ReadInput("Insert the new description of the assignment: ");
                    AssignmentManager.UpdateAssignment(id, title, description);
                    break;
                case UpdateAssignmentOptions.UpdateTitleAndSubmissionDate:
                    title = InputMethods.ReadInput("Insert the new title of the assignment: ");
                    submissionDate = InputMethods.ReadDate("Insert the new submission date and time of the assignment: ");
                    AssignmentManager.UpdateAssignment(id, title, submissionDate);
                    break;
                case UpdateAssignmentOptions.UpdateSubmissionDate:
                    submissionDate = InputMethods.ReadDate("Insert the new submission date and time of the assignment: ");
                    AssignmentManager.UpdateAssignment(id, submissionDate);
                    break;
                case UpdateAssignmentOptions.Cancel:
                    InputMethods.Cancel();
                    break;
            }
        }

        public static void DeleteAssignment()
        {
            ViewListOfAssignments();
            int id = InputMethods.ReadID("assignment", "delete");
            AssignmentManager.DeleteAssignment(id);
        }

        public static void AddTrainerToCourse()
        {
            ViewListOfTrainers();
            int trainerID = InputMethods.ReadID("trainer", "to add him a course");
            ViewListOfCourses();
            int courseID = InputMethods.ReadID("course", "to add it a trainer");
            if (!TrainerManager.AddCourseToTrainer(trainerID, courseID)){
                Console.WriteLine($"It failed to add the {trainerID} trianer to {courseID} course");
            }
        }

        public static void ViewTrainersPerCourse()
        {
            ViewListOfCourses();
            int courseID = InputMethods.ReadID("course", "to view its trainers");
            List<Trainer> trainers = CourseManager.ReadTrainersOfCourse(courseID);
            foreach (var tr in trainers)
            {
                Console.WriteLine(tr);
            }
        }

        public static void DeleteTrainerFromCourse()
        {
            ViewListOfTrainers();
            int trainerID = InputMethods.ReadID("trainer", "to delete from him a course");
            List<Course> courses = TrainerManager.ReadCoursesOfTrainer(trainerID);
            foreach (var c in courses)
            {
                Console.WriteLine(c);
            }
            int courseID = InputMethods.ReadID("course", "to delete it from the trainer");
            if (!TrainerManager.DeleteCourseFromTrainer(trainerID, courseID))
            {
                Console.WriteLine($"It failed to delete the {trainerID} trainer from {courseID} course");
            }
        }

        public static void ChangeCourseOfTrainer()
        {
            ViewListOfTrainers();
            int trainerID = InputMethods.ReadID("trainer", "to change a course");
            List<Course> courses = TrainerManager.ReadCoursesOfTrainer(trainerID);
            foreach (var c in courses)
            {
                Console.WriteLine(c);
            }
            int courseID = InputMethods.ReadID("course", "to change it from the trainer");
            ViewListOfCourses();
            int newCourseID = InputMethods.ReadID("course", "to add it a trainer");
            if (!TrainerManager.UpdateCourseFromTrainer(trainerID, courseID, newCourseID))
            {
                Console.WriteLine($"It failed the above change");
            }
        }

        public static void AddStudentToCourse()
        {
            ViewListOfStudents();
            int studentID = InputMethods.ReadID("student", "to add him a course");
            ViewListOfCourses();
            int courseID = InputMethods.ReadID("course", "to add it a student");
            if (!StudentManager.AddCourseToStudent(studentID, courseID))
            {
                Console.WriteLine($"It failed to add the {studentID} student to {courseID} course");
                return;
            }
            MarkManager.AddMarkForNewStudent(studentID, courseID);
        }

        public static void ViewStudentsPerCourse()
        {
            ViewListOfCourses();
            int courseID = InputMethods.ReadID("course", "to view its students");
            List<Student> students = CourseManager.ReadStudentsOfCourse(courseID);
            foreach (var st in students)
            {
                Console.WriteLine(st);
            }
        }

        public static void ViewAssignmentsPerCourse()
        {
            ViewListOfCourses();
            int courseID = InputMethods.ReadID("course", "to view its assignments");
            List<Assignment> assignments = CourseManager.ReadAssignmentsOfCourse(courseID);
            foreach (var assignment in assignments)
            {
                Console.WriteLine(assignment);
            }
        }

        public static void DeleteStudentFromCourse()
        {
            ViewListOfStudents();
            int studentID = InputMethods.ReadID("student", "to delete from him a course");
            List<Course> courses = StudentManager.ReadCoursesOfStudent(studentID);
            foreach (var c in courses)
            {
                Console.WriteLine(c);
            }
            int courseID = InputMethods.ReadID("course", "to delete it from the student");
            if (!StudentManager.DeleteCourseFromStudent(studentID, courseID))
            {
                Console.WriteLine($"It failed to delete the {studentID} student from {courseID} course");
                return;
            }
            MarkManager.ChangeMarkFromDbForStudentChange(studentID, courseID);
        }

        public static void ChangeCourseOfStudent()
        {
            ViewListOfStudents();
            int studentID = InputMethods.ReadID("student", "to change a course");
            List<Course> courses = StudentManager.ReadCoursesOfStudent(studentID);
            foreach (var c in courses)
            {
                Console.WriteLine(c);
            }
            int courseID = InputMethods.ReadID("course", "to change it from the student");
            ViewListOfCourses();
            int newCourseID = InputMethods.ReadID("course", "to add it a student");
            if (!StudentManager.UpdateCourseFromStudent(studentID, courseID, newCourseID))
            {
                Console.WriteLine($"It failed the above change");
                return;
            }
            MarkManager.ChangeMarkFromDb(studentID, courseID, newCourseID);
        }

        public static void ChangeCourseOfAssignment()
        {
            ViewListOfAssignments();
            int assignmentID = InputMethods.ReadID("assignment", "to change a course");
            ViewListOfCourses();
            int newCourseID = InputMethods.ReadID("course", "to add it to the assignment");
            if (!AssignmentManager.UpdateCourseOfAssignment(assignmentID, newCourseID))
            {
                Console.WriteLine($"It failed the above change");
                return;
            }
        }

        public static void ViewHeadMasters()
        {
            List<User> headMasters = UserManager.GetAllHeadMasters();
            foreach (var headMaster in headMasters)
            {
                Console.WriteLine(headMaster);
            }
        }

        public static void InsertNewHeadMaster()
        {
            string username;
            string password;
            do
            {
                username = InputMethods.ReadInput("Insert username: ");
                password = InputMethods.ReadInput("Insert password: ");
            } while (!UserManager.AddHeadMasterAccount(username, password));
        }

        public static void DeleteHeadMaster()
        {
            ViewHeadMasters();
            int id = InputMethods.ReadID("head master", "delete");
            UserManager.DeleteUser(id);
        }

        public static void ChangePassword(int id)
        {
            Console.WriteLine("You have chosen to change your password");
            string oldPassword;
            string newPassword;
            do
            {
                oldPassword = InputMethods.ReadInput("Insert your current password: ");
                newPassword = InputMethods.ReadInput("Insert your new password: ");
            } while (!UserManager.ChangePassword(id, oldPassword, newPassword));
        }
        
        public static void ChangeUsername(int id)
        {
            Console.WriteLine("You have chosen to change your username");
            string newUsername;
            do
            {
                newUsername = InputMethods.ReadInput("Insert your new username: ");
            } while (!UserManager.ChangeUsername(id, newUsername));
        }

        public static void HeadMaster(int id)
        {
            HeadMasterMenuOptions option = new HeadMasterMenuOptions();
            Console.WriteLine("\nUsing this program, you have the following options:");
            DisplayMenuOptions();
            bool exit = false;
            do
            {
                option = (HeadMasterMenuOptions)GenericEnum.InsertOption<HeadMasterMenuOptions>();
                switch (option)
                {
                    case HeadMasterMenuOptions.DisplayOptions:
                        DisplayMenuOptions();
                        break;
                    case HeadMasterMenuOptions.InsertNewCourse:
                        InsertNewCourse();
                        break;
                    case HeadMasterMenuOptions.ViewListOfCourses:
                        ViewListOfCourses();
                        break;
                    case HeadMasterMenuOptions.UpdateCourseInfos:
                        UpdateCourseInfos();
                        break;
                    case HeadMasterMenuOptions.DeleteCourse:
                        DeleteCourse();
                        break;
                    case HeadMasterMenuOptions.InsertNewStudent:
                        InsertNewStudent();
                        break;
                    case HeadMasterMenuOptions.ViewListOfStudents:
                        ViewListOfStudents();
                        break;
                    case HeadMasterMenuOptions.UpdateStudentInfos:
                        UpdateStudentInfos();
                        break;
                    case HeadMasterMenuOptions.DeleteStudent:
                        DeleteStudent();
                        break;
                    case HeadMasterMenuOptions.InsertNewTrainer:
                        InsertNewTrainer();
                        break;
                    case HeadMasterMenuOptions.ViewListOfTrainers:
                        ViewListOfTrainers();
                        break;
                    case HeadMasterMenuOptions.UpdateTrainerInfos:
                        UpdateTrainerInfos();
                        break;
                    case HeadMasterMenuOptions.DeleteTrainer:
                        DeleteTrainer();
                        break;
                    case HeadMasterMenuOptions.InsertNewAssignment:
                        InsertNewAssignment();
                        break;
                    case HeadMasterMenuOptions.ViewListOfAssignments:
                        ViewListOfAssignments();
                        break;
                    case HeadMasterMenuOptions.UpdateAssignmentInfos:
                        UpdateAssignmentInfos();
                        break;
                    case HeadMasterMenuOptions.DeleteAssignment:
                        DeleteAssignment();
                        break;
                    case HeadMasterMenuOptions.InsertStudentToCourse:
                        AddStudentToCourse();
                        break;
                    case HeadMasterMenuOptions.DeleteStudentFromCourse:
                        DeleteStudentFromCourse();
                        break;
                    case HeadMasterMenuOptions.ViewStudentsPerCourse:
                        ViewStudentsPerCourse();
                        break;
                    case HeadMasterMenuOptions.ChangeCourseOfStudent:
                        ChangeCourseOfStudent();
                        break;
                    case HeadMasterMenuOptions.InsertTrainerToCourse:
                        AddTrainerToCourse();
                        break;
                    case HeadMasterMenuOptions.DeleteTrainerFromCourse:
                        DeleteTrainerFromCourse();
                        break;
                    case HeadMasterMenuOptions.ViewTrainersPerCourse:
                        ViewTrainersPerCourse();
                        break;
                    case HeadMasterMenuOptions.ChangeCourseOfTrainer:
                        ChangeCourseOfTrainer();
                        break;
                    case HeadMasterMenuOptions.InsertAssignmentToCourse:
                        Console.WriteLine("All assignments can have only one course and it is inserted during the creation of the assignment!");
                        break;
                    case HeadMasterMenuOptions.DeleteAssignmentFromCourse:
                        Console.WriteLine("You can only change the course of an assignment, otherwise choose to delete the assignment!");
                        break;
                    case HeadMasterMenuOptions.ViewAssignmentsPerCourse:
                        ViewAssignmentsPerCourse();
                        break;
                    case HeadMasterMenuOptions.ChangeCourseOfAssignment:
                        ChangeCourseOfAssignment();
                        break;
                    case HeadMasterMenuOptions.ViewHeadMasters:
                        ViewHeadMasters();
                        break;
                    case HeadMasterMenuOptions.InsertNewHeadMaster:
                        InsertNewHeadMaster();
                        break;
                    case HeadMasterMenuOptions.DeleteHeadMaster:
                        DeleteHeadMaster();
                        break;
                    case HeadMasterMenuOptions.ChangePassword:
                        ChangePassword(id);
                        break;
                    case HeadMasterMenuOptions.ChangeUsername:
                        ChangeUsername(id);
                        break;
                    case HeadMasterMenuOptions.LogOut:
                        exit = true;
                        Console.WriteLine("\nLogged out.\n");
                        break;
                }
            } while (!exit);
        }
    }
}
