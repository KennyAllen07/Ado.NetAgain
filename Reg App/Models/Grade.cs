using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;

namespace Reg_App.Models
{
    
      public class Grade
    {
        public string JambReg{get; set;}
        
        public int Jamb{get; set;}
        public string English {get; set;}
        public string Mathematics{get; set;}
        public string Physics {get; set;}
        public string Chemistry{get; set;}
        public string Biology{get; set;}
        public string AdditionalMathematics {get; set;}
        public string TechnicalDrawing {get; set;}
        public string Agriculture {get; set;}
        public string CivicEducation {get; set;}
        public double Total {get; set;}
       
        public Grade(string jambReg, int jamb, string english, string mathematics, string physics, string chemistry, string biology, string additionalMathematics, string technicalDrawing, string agriculture, string civicEducation, double total)
        {
            JambReg = jambReg;
            Jamb = jamb;
            English = english;
            Mathematics = mathematics;
            Physics = physics;
            Chemistry = chemistry;
            Biology = biology;
            AdditionalMathematics = additionalMathematics;
            TechnicalDrawing = technicalDrawing;
            Agriculture = agriculture;
            CivicEducation = civicEducation;
            Total = total;
            
           
            
        }
        //     internal static Grade FormatLine(string line)
        // {

        //     var props = line.Split('\t');
            
        //     var jambReg = props[0];
        //     var jamb =  int.Parse(props[1]);
        //     var english = props[2];
        //     var mathematics = props[3];
        //     var physics = props[4];
        //     var chemistry = props[5];
        //     var biology = props[6];
        //     var additionalMathematics = props[7];
        //     var technicalDrawing = props[8];
        //     var agriculture = props[9];
        //     var civicEducation = props[10];
        //     var total = double.Parse(props[11]);
        //     return new Grade(jambReg, jamb, english, mathematics, physics, chemistry, biology, additionalMathematics, technicalDrawing, agriculture, civicEducation, total);

        //     //return new Grade(props[0], int.Parse(props[1]), props[2], props[3], props[4], props[5], props[6], props[7], props[8], props[9], props[10], double.Parse(props[11]));
        // }
        // public override string ToString()
        // {
        //     return $"{JambReg}\t{Jamb}\t{English}\t{Mathematics}\t{Physics}\t{Chemistry}\t{Biology}\t{AdditionalMathematics}\t{TechnicalDrawing}\t{Agriculture}\t{CivicEducation}\t{Total}";
        // }

    }
}    