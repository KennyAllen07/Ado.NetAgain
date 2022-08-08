using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;
using Reg_App.Models;
using System.IO;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Reg_App.Repo
{
    public class StaffRepo
    {
        string connect = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private static int count = 1;
      
        //private static int myIndex = 1;
        private TextWriter textWriter;
        List<Staff> staffs;

         public void AddStaff(Staff staff)
        {
              MySqlConnection Conn = null;
            try
            {
                Conn = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"insert into Staff(Firstname, Lastname, Gender, Email, Password, Address, PhoneNumber, NextOfKin, DateOfBirth, Role, AdminNo) value('{staff.FirstName}', '{staff.LastName}', '{staff.Gender}', '{staff.Email}', '{staff.Password}', '{staff.Address}', '{staff.PhoneNumber}', '{staff.NextOfKin}', '{staff.DateOfBirth}', '{staff.Role}', '{staff.StaffNo}')", Conn);
                Conn.Open();
                command.ExecuteNonQuery(); 
                Console.WriteLine("Staff Added Successfully");
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

        // public StaffRepo()
        // {
        //     staffs = new List<Staff>();
        //     string path = "Staff.txt";
        //     if (File.Exists(path))
        //     {
        //         var lines = File.ReadAllLines("Staff.txt");
        //         foreach (var line in lines)
        //         {
        //             var staff = Staff.FormatLine(line);
        //             staffs.Add(staff);
        //         }
        //     }  
        // }



        public void AddNewStaff(string fName, string lName, string email, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string password, string nextofkin, Role role)
        {
            string staffNo = $"ADMIN{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5).ToUpper()}";
            // int id = count++;
            Staff staff = new Staff(fName, lName, email, gender, dateOfBirth, address, phoneNumber, password, nextofkin, role, staffNo);
            //staffs.Add(staff);
            AddStaff(staff);
            TextWriter writer = new StreamWriter("Staff.txt", true);
            writer.WriteLine(staff.ToString());
            writer.Close();
            //Console.WriteLine("New Staff was successfully added.");
            // count++;
            //RefreshFile();
          
         
        }
         public Staff LoginStaff(string email)
        {
            MySqlConnection Conn = null;
            Staff staff = null;
            try
            {
                Conn = new MySqlConnection(connect);
                var sql = "select Firstname,Lastname,Email,Gender,Password,Address,PhoneNumber,NextOfKin,DateOfBirth,Role,AdminNo from staff where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(sql,Conn);
                Conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string FirstName = $"{(reader["Firstname"])}";
                    string LastName = $"{(reader["Lastname"])}";
                    string Email = $"{(reader["Email"])}";
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender),$"{(reader["Gender"])}");
                    string Password = $"{(reader["Password"])}";
                    string Address = $"{(reader["Address"])}";
                    string PhoneNumber = $"{(reader["PhoneNumber"])}";
                    string NextOfKin = $"{(reader["NextOfKin"])}";
                    DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                    Role Role = (Role)Enum.Parse(typeof(Role),$"{(reader["Role"])}");
                    string AdminNo = $"{(reader["AdminNo"])}";
                    
                    
                    
                    staff = new Staff(FirstName, LastName,Email, Gender, DateOfBirth, Address, PhoneNumber,Password, NextOfKin, Role, AdminNo);
                    
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Conn.Close();
            return staff;
        }

          public Staff Login(string email, string password)
        {
            var staff = LoginStaff(email);
            if(staff != null && staff.Password == password) 
            {
                
                return staff;
            }    
            return null;
         
        }
      
          public Staff GetStaff(string email)
        {
            Staff staff = null;
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
                var sql = "select Firstname,Lastname,Email,Gender,Password,Address,PhoneNumber,NextOfKin,DateOfBirth,Role,AdminNo from staff where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(sql,Conn);
                Conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string FirstName = $"{(reader["Firstname"])}";
                    string LastName = $"{(reader["Lastname"])}";
                    string Email = $"{(reader["Email"])}";
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender),$"{(reader["Gender"])}");
                    string Password = $"{(reader["Password"])}";
                    string Address = $"{(reader["Address"])}";
                    string PhoneNumber = $"{(reader["PhoneNumber"])}";
                    string NextOfKin = $"{(reader["NextOfKin"])}";
                    DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                    Role Role = (Role)Enum.Parse(typeof(Role),$"{(reader["Role"])}");
                    string AdminNo = $"{(reader["AdminNo"])}";
                    
                    
                    
                    staff = new Staff(FirstName, LastName,Email, Gender, DateOfBirth, Address, PhoneNumber,Password, NextOfKin, Role, AdminNo);
                   Conn.Close();
                   return staff; 
                }
                else{
                    return null;
                }

        }
        public Staff PrintStaff()
        {
            var staffs= ListStaff();
            foreach (var staff in staffs)
            {
                if (staff != null)
                {
                Console.WriteLine($"{staff.FirstName}|{staff.LastName}|{staff.Email}|{staff.Gender}|{staff.Password}|{staff.Address}|{staff.PhoneNumber}|{staff.NextOfKin}|{staff.DateOfBirth}|{staff.Role}|{staff.StaffNo}");
                }
            }
            return null;
        }
          public Staff DeleteStaff(string delStaff)
        {
            string email = delStaff;
            
            var staff =  GetStaff(email);
            if(staff != null)
            {
                Console.WriteLine($"You are about to fire this staff profile {staff.FirstName} {staff.LastName} Enter 1 to fire the staff or 0 to keep the staff.");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid Input Enter 1 or 0");

                }
                if (option == 1)
                {
                MySqlConnection Conn = null;
                Conn = new MySqlConnection(connect);
                var sql = "delete from staff where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(sql,Conn);
                Conn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"Staff Successfully Removed");
                Conn.Close();
                }
                else if (option == 0)
                {
                    return null;
                }
            }
         return null;
        }
        public Staff UpdateStaff(string email)
        {
        try
        {
             string Stemail = email;
        var staff = GetStaff(email);
        if (staff != null){
            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Your Gender: 1 Male \t2 Female \t3 Rather Not Say");
            int gender;
            while (!int.TryParse(Console.ReadLine().ToString(), out gender) && gender > 3 || gender < 1)
            {
                Console.WriteLine("Invalid Input Enter 1, 2 or 3");
            }
            Console.WriteLine("Enter Email");
            string Email = Console.ReadLine();
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
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            MySqlCommand command = new MySqlCommand($"update Staff set `FirstName` = '{firstName}', `LastName` = '{lastName}', `Gender` = '{gender}', `Email` = '{Email}', `Password` = '{password}', `Address` = '{address}', `PhoneNumber` = '{phoneNumber}', `NextOfKin` = '{nextOfKin}', `DateOfBirth` = '{dateOfBirth}', `Role` = '{role}' where `Email` = '{email}' ", Conn);
            Conn.Open();
            command.ExecuteNonQuery();
            Conn.Close();
            Console.WriteLine($"Your Profile has been Successfully Updated.");         
        }
        
        }
        catch (System.Exception e)
        {
            
            Console.WriteLine(e.Message);
        }
       return null;
    }
       public List <Staff> ListStaff()
        {
            List<Staff>staffs = new List<Staff>();
            
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            int count = 0;
                var sql = "select * from staff";
                var query = "select count(*)from staff"; 
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
                    Gender Gender = (Gender)Enum.Parse(typeof(Gender),$"{(reader["Gender"])}");
                    string Password = $"{(reader["Password"])}";
                    string Address = $"{(reader["Address"])}";
                    string PhoneNumber = $"{(reader["PhoneNumber"])}";
                    string NextOfKin = $"{(reader["NextOfKin"])}";
                    DateTime DateOfBirth = DateTime.Parse($"{(reader["DateOfBirth"])}");
                    Role Role = (Role)Enum.Parse(typeof(Role),$"{(reader["Role"])}");
                    string AdminNo = $"{(reader["AdminNo"])}";
                    
                    
                    
                    
                    var staff = new Staff(FirstName, LastName,Email, Gender, DateOfBirth, Address, PhoneNumber,Password, NextOfKin, Role, AdminNo);
                   staffs.Add(staff);
                   
                   
                    }
                    return staffs; 
                }
                else{
                    return null;
                }

        }

       

          private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Staff.txt");
            foreach (Staff staff in staffs)
            {
                writer.WriteLine(staff);
            }
            writer.Flush();
            writer.Close();
        }
       
    }

}
