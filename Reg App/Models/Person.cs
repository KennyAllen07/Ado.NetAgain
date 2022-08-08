using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;

namespace Reg_App.Models
{
     public abstract class Person
    {
        
        public string FirstName {get; set;}
        public string LastName{get; set;}
        public string Email {get; set;}
        public Gender Gender {get; set;}
        public DateTime DateOfBirth {get; set;}
        public int Age{get; set;}
        public string Address{get; set;}
        public string PhoneNumber{get; set;}
        public string Password {get; set;}
        public string NextOfKin {get; set;}
        protected Person(string firstName, string lastName, string email, Gender gender, DateTime dateOfBirth,  string address, string phoneNumber, string password, string nextofkin)
        {
            
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            Password = password;
            NextOfKin = nextofkin;
        }
          public string FullName()
       {
          return $"{FirstName} {LastName}";
       }    
    }
}    
