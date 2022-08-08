using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;

namespace Reg_App.Models
{
      public class Student:Person
    {
        public string RegNo {get; set;}
      
         public Courses Courses{get; set;}

         public Courses1 Courses1{get; set;}
       


   
        
         public Student(string firstName, string lastName, string email, string regNo, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string password, string nextofkin, Courses courses, Courses1 courses1): base(firstName,  lastName,  email,  gender, dateOfBirth,  address,  phoneNumber,  password,  nextofkin)

       {
           RegNo = regNo;
           Courses = courses;
           Courses1 = courses1;
       }
       public string FullName()
       {
          return $"{FirstName} {LastName}";
       }   
        // internal static Student FormatLine(string line)
        // {
        //     var props = line.Split('\t');
        //     return new Student(int.Parse(props[0]), props[1], props[2], props[3], props[4], (Gender)Enum.Parse(typeof(Gender),props[5]), DateTime.Parse(props[6]), props[7], props[8], props[9], props[10], (Courses)Enum.Parse(typeof(Courses),props[11]), (Courses1)Enum.Parse(typeof(Courses1),props[12]));
        // }
        //  public override string ToString()
        // {
        //     return $"{Id}\t{FirstName}\t{LastName}\t{Email}\t{RegNo}\t{Gender}\t{DateOfBirth}\t{Address}\t{PhoneNumber}\t{Password}\t{NextOfKin}\t{Courses}\t{Courses1}";
        // } 
    }
}