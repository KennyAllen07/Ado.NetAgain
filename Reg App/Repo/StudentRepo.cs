using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;
using Reg_App.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Reg_App.Repo
{
    public class StudentRepo
    {

        string connect = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private TextWriter textWriter;
        List<Student> students;

        public void AddStudent(Student student)
        {
            MySqlConnection Conn = null;
            try
            {
                Conn = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"insert into Student(Firstname, Lastname, Email, RegNo, Gender, DateOfBirth, Address, PhoneNumber, Password, NextOfKin, 1st_Choice_Course, 2nd_Choice_Course) value('{student.FirstName}', '{student.LastName}', '{student.Email}', '{student.RegNo}', '{student.Gender}', '{student.DateOfBirth}', '{student.Address}', '{student.PhoneNumber}', '{student.Password}', '{student.NextOfKin}', '{student.Courses}', '{student.Courses1}')", Conn);
                Conn.Open();
                command.ExecuteNonQuery();
                //Console.WriteLine("Staff Added Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong");

            }
            finally
            {
                Conn.Close();
            }
        }

        //   public StudentRepo()
        // {
        //     students = new List<Student>();
        //     string path = "Student.txt";
        //     if (File.Exists(path))
        //     {
        //         var lines = File.ReadAllLines("Student.txt");
        //         foreach (var line in lines)
        //         {
        //             var student = Student.FormatLine(line);
        //             students.Add(student);
        //         }
        //     }  
        // }



        //private static int count = 1;


        public void Register(string firstName, string lastName, string email, string regNo, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string password, string nextofkin, Courses courses, Courses1 courses1)
        {
            var student = new Student(firstName, lastName, email, regNo, gender, dateOfBirth, address, phoneNumber, password, nextofkin, courses, courses1);
            //students.Add(student);
            AddStudent(student);
            // TextWriter writer = new StreamWriter("Student.txt", true);
            // writer.WriteLine(student.ToString());
            // writer.Close();
            Console.WriteLine($"You have successfully created an account and your registration number is {student.RegNo}");
            //count++;
            //RefreshFile();
            //myIndex++;

        }
        public Student LoginStudent(string email)
        {
            MySqlConnection Conn = null;
            Student student = null;
            try
            {
                Conn = new MySqlConnection(connect);
                var sql = "select Firstname,Lastname,Email,RegNo,Gender,DateOfBirth,Address,PhoneNumber,Password,NextOfKin,1st_Choice_Course,2nd_Choice_Course from student where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(sql, Conn);
                Conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string FirstName = $"{(reader["Firstname"])}";
                    string LastName = $"{(reader["Lastname"])}";
                    string Email = $"{(reader["Email"])}";
                    string RegNo = $"{(reader["RegNo"])}";
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{(reader["Gender"])}");
                    DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                    string Address = $"{(reader["Address"])}";
                    string PhoneNumber = $"{(reader["PhoneNumber"])}";
                    string Password = $"{(reader["Password"])}";
                    string NextOfKin = $"{(reader["NextOfKin"])}";

                    Courses Courses = (Courses)Enum.Parse(typeof(Courses), $"{(reader["1st_Choice_Course"])}");
                    Courses1 Courses1 = (Courses1)Enum.Parse(typeof(Courses1), $"{(reader["2nd_Choice_Course"])}");




                    student = new Student(FirstName, LastName, Email, RegNo, Gender, DateOfBirth, Address, PhoneNumber, Password, NextOfKin, Courses, Courses1);

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Conn.Close();
            return student;
        }
        public Student Login(string email, string password)
        {
            var student = LoginStudent(email);
            if (student != null && student.Password == password)
            {
                return student;
            }
            return null;

        }
        public Student Registration(string regNo)
        {
            foreach (var a in students)
            {
                if (a != null && a.RegNo == regNo)
                {
                    return a;
                }
            }
            return null;
        }
        private static string HoldRegNo;

        public void Regis(string regNo)
        {
            HoldRegNo = regNo;
        }
        private Student GetStudent(string email)
        {
            Student student = null;
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            var sql = "select Firstname,Lastname,Email,RegNo,Gender,Password,Address,PhoneNumber,NextOfKin,DateOfBirth,1st_Choice_Course,2nd_Choice_Course from student where email = '" + email + "'";
            MySqlCommand command = new MySqlCommand(sql, Conn);
            Conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string FirstName = $"{(reader["Firstname"])}";
                string LastName = $"{(reader["Lastname"])}";
                string Email = $"{(reader["Email"])}";
                string RegNo = $"{(reader["RegNo"])}";
                Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{(reader["Gender"])}");
                string Password = $"{(reader["Password"])}";
                string Address = $"{(reader["Address"])}";
                string PhoneNumber = $"{(reader["PhoneNumber"])}";
                string NextOfKin = $"{(reader["NextOfKin"])}";
                DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                Courses Courses = (Courses)Enum.Parse(typeof(Courses), $"{(reader["1st_Choice_Course"])}");
                Courses1 Courses1 = (Courses1)Enum.Parse(typeof(Courses1), $"{(reader["2nd_Choice_Course"])}");




                student = new Student(FirstName, LastName, Email, RegNo, Gender, DateOfBirth, Address, PhoneNumber, Password, NextOfKin, Courses, Courses1);
                Conn.Close();
                return student;
            }
            else
            {
                return null;
            }

        }
        private Student GetStudentReg(string regNo)
        {
            Student student = null;
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            var sql = "select Firstname,Lastname,Email,RegNo,Gender,Password,Address,PhoneNumber,NextOfKin,DateOfBirth,1st_Choice_Course,2nd_Choice_Course from student where RegNo = '" + regNo + "'";
            MySqlCommand command = new MySqlCommand(sql, Conn);
            Conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string FirstName = $"{(reader["Firstname"])}";
                string LastName = $"{(reader["Lastname"])}";
                string Email = $"{(reader["Email"])}";
                string RegNo = $"{(reader["RegNo"])}";
                Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{(reader["Gender"])}");
                string Password = $"{(reader["Password"])}";
                string Address = $"{(reader["Address"])}";
                string PhoneNumber = $"{(reader["PhoneNumber"])}";
                string NextOfKin = $"{(reader["NextOfKin"])}";
                DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                Courses Courses = (Courses)Enum.Parse(typeof(Courses), $"{(reader["1st_Choice_Course"])}");
                Courses1 Courses1 = (Courses1)Enum.Parse(typeof(Courses1), $"{(reader["2nd_Choice_Course"])}");




                student = new Student(FirstName, LastName, Email, RegNo, Gender, DateOfBirth, Address, PhoneNumber, Password, NextOfKin, Courses, Courses1);
                Conn.Close();
                return student;
            }
            else
            {
                return null;
            }

        }
        public Student StaffStudent()
        {
            MySqlConnection Conn = null;
            Student student = null;
            try
            {
                Conn = new MySqlConnection(connect);
                var sql = "select * from student";
                MySqlCommand command = new MySqlCommand(sql, Conn);
                Conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string FirstName = $"{(reader["Firstname"])}";
                    string LastName = $"{(reader["Lastname"])}";
                    string Email = $"{(reader["Email"])}";
                    string RegNo = $"{(reader["RegNo"])}";
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{(reader["Gender"])}");
                    DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                    string Address = $"{(reader["Address"])}";
                    string PhoneNumber = $"{(reader["PhoneNumber"])}";
                    string Password = $"{(reader["Password"])}";
                    string NextOfKin = $"{(reader["NextOfKin"])}";

                    Courses Courses = (Courses)Enum.Parse(typeof(Courses), $"{(reader["1st_Choice_Course"])}");
                    Courses1 Courses1 = (Courses1)Enum.Parse(typeof(Courses1), $"{(reader["2nd_Choice_Course"])}");




                    student = new Student(FirstName, LastName, Email, RegNo, Gender, DateOfBirth, Address, PhoneNumber, Password, NextOfKin, Courses, Courses1);

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Conn.Close();
            return student;
        }
        public Student GetStudentStaff()
        {
              var students= ListStudent();
            foreach (var student in students)
            {
                if (student != null)
                {
                Console.WriteLine($"{student.FirstName}|{student.LastName}|{student.Email}|{student.RegNo}|{student.Gender}|{student.DateOfBirth}|{student.Address}|{student.PhoneNumber}|{student.Password}|{student.NextOfKin}|{student.Courses}|{student.Courses1}");
                }
            }
            return null;
        }
    
        public Student UpdateStudent(string regNo)
        {
            string Stemail = regNo;
            var student = GetStudentReg(regNo);
            if (student != null)
            {
                Console.WriteLine("Enter Your First Name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Your Last Name");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Your Gender: 1 Male \t2 Female \t3 Rather Not Say");
                int gender;
                while (!int.TryParse(Console.ReadLine().ToString(), out gender) && gender > 3 || gender < 1)
                {
                    Console.WriteLine("Invalid Input Enter 1, 2 or 3");
                }
                Console.WriteLine("Enter Your Email");
                string Email = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();

                Console.WriteLine("Enter Your Address");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Your Phone Number");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Your next Of Kin");
                string nextOfKin = Console.ReadLine();
                Console.WriteLine("Enter Your Date Of Birth in the format (YYYY-MM-DD)");
                DateTime dateOfBirth;
                while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    Console.WriteLine("Invalid Input Your Date of Birth again");
                }
                Console.WriteLine("Enter Your Most Preffered Course: 1.Engineering \t2.Medicine \t3.Agriculture \t4.Statistics \t5.Physics \t6.Chemistry \t7.Biology \t8.BioChemistry \t9.Geology \t10.Physiology \t11.Anatomy \t12.Pharmacy \t13.AnimalScience \t14.Botany \t15.Zoology \t16.ComputerScience: ");
                int courses;
                while (!int.TryParse(Console.ReadLine(), out courses) && courses > 16 || courses < 1)
                {
                    Console.WriteLine("Invalid Input Enter a number corresponding to the courses set above");
                }
                Console.WriteLine("Enter Your 2nd Most Preffered Course: 1.Engineering \t2.Medicine \t3.Agriculture \t4.Statistics \t5.Physics \t6.Chemistry \t7.Biology \t8.BioChemistry \t9.Geology \t10.Physiology \t11.Anatomy \t12.Pharmacy \t13.AnimalScience \t14.Botany \t15.Zoology \t16.ComputerScience: ");
                int courses1;
                while (!int.TryParse(Console.ReadLine(), out courses1) && courses1 > 16 || courses1 < 1)
                {
                    Console.WriteLine("Invalid Input Enter a number corresponding to the courses set above");
                }
                MySqlConnection Conn = null;
                Conn = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"update Student set `FirstName` = '{firstName}', `LastName` = '{lastName}', `Gender` = '{gender}', `Email` = '{Email}', `Password` = '{password}', `Address` = '{address}', `PhoneNumber` = '{phoneNumber}', `NextOfKin` = '{nextOfKin}', `DateOfBirth` = '{dateOfBirth}', `1st_Choice_Course` = '{courses}', `2nd_Choice_Course` = '{courses1}' where `RegNo` = '{regNo}' ", Conn);
                Conn.Open();
                command.ExecuteNonQuery();
                Conn.Close();
                Console.WriteLine($"Your Profile has been Successfully Updated.");
            }
            return null;
        }
        public Staff DeleteStudent(string DeleteStudent)
        {
            string regNo = DeleteStudent;

            var student = GetStudentReg(regNo);
            if (student != null)
            {
                Console.WriteLine($"You are about to delete this student profile {student.FirstName} {student.LastName} Enter 1 to delete the profile or 0 to abort.");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid Input Enter 1 or 0");

                }
                if (option == 1)
                {
                    MySqlConnection Conn = null;
                    Conn = new MySqlConnection(connect);
                    var sql = "delete from student where regNo = '" + regNo + "'";
                    MySqlCommand command = new MySqlCommand(sql, Conn);
                    Conn.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Student Successfully Deleted");
                    Conn.Close();
                }
                else if (option == 0)
                {
                    return null;
                }
            }
            return null;
        }

        public Student GetStudentDetails(string regNo)
        {
            Student student = null;
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            var sql = "select Firstname,Lastname,Email,RegNo,Gender,Password,Address,PhoneNumber,NextOfKin,DateOfBirth,1st_Choice_Course,2nd_Choice_Course from student where RegNo = '" + regNo + "'";
            MySqlCommand command = new MySqlCommand(sql, Conn);
            Conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"Firstname: {(reader["Firstname"])}");
                Console.WriteLine($"Lastname: {(reader["Lastname"])}");
                Console.WriteLine($"Email: {(reader["Email"])}");
                Console.WriteLine($"RegNo: {(reader["RegNo"])}");
                Console.WriteLine($"Gender: {(reader["Gender"])}");
                Console.WriteLine($"Address: {(reader["Address"])}");
                Console.WriteLine($"Phone Number: {(reader["PhoneNumber"])}");
                Console.WriteLine($"Next Of Kin: {(reader["NextOfKin"])}");
                Console.WriteLine($"Date Of Birth: {(reader["DateOfBirth"])}");
                Console.WriteLine($"1st Choice Course: {(reader["1st_Choice_Course"])}");
                Console.WriteLine($"2nd Choice Course: {(reader["2nd_Choice_Course"])}");
                Conn.Close();
                return student;
            }
            else
            {
                return null;
            }

        }
         public Student GetAllStudentDetails()
        {
            Student student = null;
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            var sql = "select Firstname,Lastname,Email,RegNo,Gender,Password,Address,PhoneNumber,NextOfKin,DateOfBirth,1st_Choice_Course,2nd_Choice_Course from student";
            MySqlCommand command = new MySqlCommand(sql, Conn);
            Conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("//////////");
                Console.WriteLine($"Firstname: {(reader["Firstname"])}");
                Console.WriteLine($"Lastname: {(reader["Lastname"])}");
                Console.WriteLine($"Email: {(reader["Email"])}");
                Console.WriteLine($"RegNo: {(reader["RegNo"])}");
                Console.WriteLine($"Gender: {(reader["Gender"])}");
                Console.WriteLine($"Password: {(reader["Password"])}");
                Console.WriteLine($"Address: {(reader["Address"])}");
                Console.WriteLine($"Phone Number: {(reader["PhoneNumber"])}");
                Console.WriteLine($"Next Of Kin: {(reader["NextOfKin"])}");
                Console.WriteLine($"Date Of Birth: {(reader["DateOfBirth"])}");
                Console.WriteLine($"1st Choice Course: {(reader["1st_Choice_Course"])}");
                Console.WriteLine($"2nd Choice Course: {(reader["2nd_Choice_Course"])}");
                Console.WriteLine("//////////");
                Conn.Close();
                return student;
            }
            else
            {
                return null;
            }

        }
         public List <Student> ListStudent()
        {
            List<Student>students = new List<Student>();
            
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            int count = 0;
                var sql = "select * from student";
                var query = "select count(*)from student"; 
                MySqlCommand command = new MySqlCommand(sql,Conn);
                MySqlCommand countCommand = new MySqlCommand(query, Conn);
                Conn.Open();
                using (countCommand)
                {
                    count = Convert.ToInt32(countCommand.ExecuteScalar());
                }
                MySqlDataReader reader = command.ExecuteReader();

                if (count != 0)
                {
                    for(var i = 0; i < count; i++)
                    {
                    reader.Read();
                    string FirstName = $"{(reader["Firstname"])}";
                    string LastName = $"{(reader["Lastname"])}";
                    string Email = $"{(reader["Email"])}";
                    string RegNo = $"{(reader["RegNo"])}";
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender), $"{(reader["Gender"])}");
                    DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                    string Address = $"{(reader["Address"])}";
                    string PhoneNumber = $"{(reader["PhoneNumber"])}";
                    string Password = $"{(reader["Password"])}";
                    string NextOfKin = $"{(reader["NextOfKin"])}";
                    Courses Courses = (Courses)Enum.Parse(typeof(Courses), $"{(reader["1st_Choice_Course"])}");
                    Courses1 Courses1 = (Courses1)Enum.Parse(typeof(Courses1), $"{(reader["2nd_Choice_Course"])}");

                    
                    
                    
                    
                    var student = new Student(FirstName, LastName, Email, RegNo, Gender, DateOfBirth, Address, PhoneNumber, Password, NextOfKin, Courses, Courses1);
                   students.Add(student);
                   
                   
                    }
                    return students; 
                }
                else{
                    return null;
                }

        }

        //  private void RefreshFile()
        // {
        //     TextWriter writer = new StreamWriter("Student.txt");
        //     foreach (Student student in students)
        //     {
        //         writer.WriteLine(student);
        //     }
        //     writer.Flush();
        //     writer.Close();
        // }

    }

}
