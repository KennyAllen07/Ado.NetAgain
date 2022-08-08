using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;

namespace Reg_App.Models
{
    public class Staff:Person
    {
       public string StaffNo {get; set;}
       public Role Role {get; set;}
       public Staff(string firstName, string lastName, string email, Gender gender, DateTime dateOfBirth, string address, string phoneNumber, string password, string nextofkin, Role role, string staffNo): 
       base( firstName, lastName,  email,  gender, dateOfBirth,  address,  phoneNumber,  password,  nextofkin)

       {
           Role = role;
           StaffNo = staffNo;
           

       }
        //  internal static Staff FormatLine(string line)
        // {
        //     var props = line.Split('\t');
        //     return new Staff(int.Parse(props[0]), props[1], props[2], props[3], (Gender)Enum.Parse(typeof(Gender),props[4]), DateTime.Parse(props[5]), props[6], props[7], props[8], props[9], (Role)Enum.Parse(typeof(Role),props[10]));
        // } 
        //   public override string ToString()
        // {
        //     return $"{Id}\t{FirstName}\t{LastName}\t{Email}\t{Gender}\t{DateOfBirth}\t{Address}\t{PhoneNumber}\t{Password}\t{NextOfKin}\t{Role}\t{StaffNo}";
        // } 
       

        // public static Staff ToStaff(string str)
        // {
        //     var myadmin = str.Split("\t");
        //     var firstname = myadmin[0];
        //     var lastname = myadmin[1];
        //     var email = myadmin[2];
        //     var password = myadmin[3];
        //     return new Staff(id, firstname, lastname, email, password);
        // }

    }
}