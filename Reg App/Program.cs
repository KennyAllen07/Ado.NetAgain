
using System;
using System.Collections.Generic;
using Reg_App.Repo;
using Reg_App.Menus;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace Reg_App.Manage
{
    
    class Program
    {
        string connect = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();
            // StudentMenu studentMenu =  new StudentMenu();
            // studentMenu.Menu();
        // StaffMenu staffMenu = new StaffMenu();
        // staffMenu.Menu();
        //    new Program().Createtable();
        //     Console.ReadKey();    
        }  
        public void Createtable()
        { 
           
            MySqlConnection Conn = null;
            try
            {
                Conn = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand("create table Student(id int not null auto_increment primary key, Firstname varchar(200), Lastname varchar(200), Email varchar(255), RegNo varchar(65), Gender varchar(65), DateOfBirth varchar(200), Address varchar(255), PhoneNumber varchar(200), Password varchar(100), NextOfKin varchar(200), 1st_Choice_Course varchar(255), 2nd_Choice_Course varchar(255))", Conn);
                Conn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                Conn.Close();
            }
        }
        public void AddStudent()
        {
              MySqlConnection Conn = null;
            try
            {
                Conn = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand("insert into Staff(Firstname, Lastname, Gender, Email, Password, Address, PhoneNumber, NextOfKin, DateOfBirth, Role, AdminNo) value('Kehinde', 'Makinde', 'Male', 'kehinde.makinde07@gmail.com', 'KennyAllen07', 'Bergen, Norway', '+2348160375199', 'Alan', '2004-08-13', 'Main', 'ADMIN00001')", Conn);
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
    }
}
