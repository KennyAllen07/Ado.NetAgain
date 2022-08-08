using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;
using Reg_App.Models;
using Reg_App.Repo;
namespace Reg_App.Menus
{
    public class StaffMenu
    {

        StaffRepo staffRepo = new StaffRepo();
        StudentRepo studentRepo = new StudentRepo();
        GradeRepo gradeRepo = new GradeRepo();
        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("0. Exit");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    // case 1:
                    // AddNewStaff();
                    // break;
                    case 1:
                    Login();
                    break;
                    case 0:
                    exit = true;
                    break;
                    default:
                    break;
                        
                }
            }
        }
        public void ManagerMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Staff Management");
                Console.WriteLine("2. Student Management");
                Console.WriteLine("0. Go Back");
                
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        StaffManageMentDashBoard();
                        break;
                    case 2:
                        StudentManagementDashboard();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        
         public void StaffManageMentDashBoard()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add New Staff");
                Console.WriteLine("2. Get Staff");
                Console.WriteLine("3. Update Profile");
                Console.WriteLine("4. View Profile");
                Console.WriteLine("5. Delete Staff");
                Console.WriteLine("0. Go Back");
                
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        AddNewStaff();
                        break;
                    case 2:
                        staffRepo.PrintStaff();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Check();
                        break;
                    case 5:
                        Remove();
                        break;
                    case 0:

                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        
        public void StudentManagementDashboard()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Get Specific Student Profile");
                Console.WriteLine("2. Get All Students");
                Console.WriteLine("3. Get Specific Student Result");
                Console.WriteLine("4. Get All Students Results");             
                Console.WriteLine("5. Delete Student Profile");
                Console.WriteLine("6. Delete Grade Profile");
                Console.WriteLine("0. Go Back");
                
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                     case 1:
                        GetStudent();
                        break;
                    case 2:
                        studentRepo.GetAllStudentDetails();
                        break;
                    case 3:
                        GetSpecStudent();
                        break;
                    case 4:
                        gradeRepo.GetAllStudentResult();
                        break;
                    case 5:
                        DeleteStudent();
                        break;
                    case 6:
                        DeleteGrade();
                        break;                           
                    case 0:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
         public void StaffsMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add New Staff");
                Console.WriteLine("2. Get Staff");
                Console.WriteLine("3. Get All Students");
                Console.WriteLine("4. Update Profile");
                Console.WriteLine("5. View Profile");
                Console.WriteLine("0. Go Back");
                
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        AddNewStaff();
                        break;
                    case 2:
                        staffRepo.PrintStaff();
                        break;
                    case 3:
                        studentRepo.GetStudentStaff();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Check();
                        break;     
                    case 0:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public void Login()
        {
            Console.WriteLine("Enter Your Email Address: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();
            var staff = staffRepo.Login(email, password);
            if(staff != null && staff.Role == Role.Main)
            {
                Console.WriteLine(staff.FullName());
                ManagerMenu();
            }
            else if(staff != null && staff.Role == Role.Admin)
            {
                Console.WriteLine(staff.FullName());
                StaffsMenu();
            }
            else
            {
                Console.WriteLine("Invalid email or password");
                Login();
            }
        }
         public void Remove()
        {
            Console.WriteLine("Enter Your Email Address");
            string email = Console.ReadLine();
            var staff = staffRepo.DeleteStaff(email);
         
        }
          public void DeleteStudent()
        {
            Console.WriteLine("Enter A Registration Number");
            string regNo = Console.ReadLine();
            var staff = studentRepo.DeleteStudent(regNo);
         
        }
           public void DeleteGrade()
        {
            Console.WriteLine("Enter A Registration Number: ");
            string regNo = Console.ReadLine();
            var staff = gradeRepo.DeleteGrade(regNo);
         
        }
          public void Update()
        {
            Console.WriteLine("Enter Your Email Address: ");
            string email = Console.ReadLine();
            var staff = staffRepo.UpdateStaff(email);
         
        }        
        public void AddNewStaff()
        {
            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Your Gender: 1 Male \t2 Female \t3 Rather Not Say");
            int gender;
            while (!int.TryParse(Console.ReadLine(), out gender) && gender > 3 || gender < 1)
            {
                Console.WriteLine("Invalid Input Enter 1, 2 or 3");
            }
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
           
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter next Of Kin");
            string nextOfKin = Console.ReadLine();
            Console.WriteLine("Enter Date Of Birth(YYYY-MM-DD)");
            DateTime dateOfBirth;
             while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth)){
                Console.WriteLine("Invalid Input Your Date of Birth again");
            }
            Console.WriteLine("Enter Role \t 1. Main Admin \t 2. Admin");
            int role;
            while (!int.TryParse(Console.ReadLine(), out role) && role > 3 || role < 1)
            {
                Console.WriteLine("Invalid Input Enter 1 or 2");
            }

            staffRepo.AddNewStaff(firstName, lastName, email, (Gender)gender, dateOfBirth, address, phoneNumber, password, nextOfKin, (Role)role);
        }

        public void GetSpecStudent()
        {
            Console.WriteLine("Enter the student's Registration Number: ");
            string regNo = Console.ReadLine();
            gradeRepo.GetGrade(regNo);
        }
        public void GetStudent()
        {
            Console.WriteLine("Enter the student's Registration Number: ");
            string regNo = Console.ReadLine();
            studentRepo.GetStudentDetails(regNo);
        }
            public void Check()
        {
            Console.WriteLine("Enter your email address: ");
            string email = Console.ReadLine();
            var staff = staffRepo.GetStaff(email);
         
        }

       
         public void HookScreen()
        {
            Console.WriteLine("Invalid Entry\n Enter any key to continue:");
            Console.ReadKey();
        }
    }

}



