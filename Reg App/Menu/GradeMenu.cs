using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reg_App.Enums;
using Reg_App.Models;
using Reg_App.Repo;
namespace Reg_App.Menus;
    public class GradeMenu
    {
        GradeRepo gradeRepo = new GradeRepo();
        StudentRepo studentRepo = new StudentRepo();

        private static string HoldRegNo;

        public void Regis(string regis)
        {
            HoldRegNo = regis;
        }
        
       
        public void GradesMenu()
        {
            bool cont = false;
            while (!cont)
            {
                PrintSubMenu();
                {
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            DetailsMenu();
                            break;
                        case 2:
                            CheckResult();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            UpdateGrades();
                            break;
                        case 5:
                            Check();
                            break;        
                        case 0:
                           cont = true;
                            break;
                       
                    }

                }
            }
        }

        public void PrintSubMenu()
        {
            Console.WriteLine("1. Fill in Grade Details: ");
            Console.WriteLine("2. View Grade Profile: ");
            Console.WriteLine("3. Update Student Profile");
            Console.WriteLine("4. Update Grade Profile");
            Console.WriteLine("5. View Student Profile");
            Console.WriteLine("0. Go Back");
        }

       
             public void UpdateGrades()
        {
            Console.WriteLine("Enter Your Registration Number");
            string regNo = Console.ReadLine();
            var staff = gradeRepo.UpdateGrade(regNo);
         
        }        
        

        
        public void DetailsMenu()
       
           
        {
            string jambReg = HoldRegNo;
            Console.WriteLine("Enter your Jamb Score: ");
            int jamb;
            while (!int.TryParse(Console.ReadLine(), out jamb))
            {
                Console.WriteLine("Enter your Jamb Score: ");
            }
            
            Console.WriteLine("Enter your WAEC Grades in Capital Letters.");
            Console.WriteLine("Enter your grade in English: ");
            string english = Console.ReadLine().ToUpper();
            int eng = WaecScore(english);
             Console.WriteLine("Enter your grade in Mathematics: ");
            string mathematics = Console.ReadLine().ToUpper();
            int math = WaecScore(mathematics);
             Console.WriteLine("Enter your grade in Physics: ");
            string physics = Console.ReadLine().ToUpper();
            int phy = WaecScore(physics);
             Console.WriteLine("Enter your grade in Chemistry: ");
            string chemistry = Console.ReadLine().ToUpper();
            int chm = WaecScore(chemistry);
             Console.WriteLine("Enter your grade in Biology: ");
            string biology = Console.ReadLine().ToUpper();
            int bio = WaecScore(biology);
             Console.WriteLine("Enter your grade in Additional Mathematics: ");
            string additionalMathematics = Console.ReadLine().ToUpper();
            int addMath = WaecScore(additionalMathematics);
             Console.WriteLine("Enter your grade in Technical Drawing: ");
            string technicalDrawing = Console.ReadLine().ToUpper();
            int techDraw = WaecScore(technicalDrawing);
             Console.WriteLine("Enter your grade in Agriculture: ");
            string agriculture = Console.ReadLine().ToUpper();
            int agric = WaecScore(agriculture);
             Console.WriteLine("Enter your grade in Civic Education: ");
            string civicEducation = Console.ReadLine().ToUpper();
            int civic = WaecScore(civicEducation);
            double JB = (jamb/400.0) * 50.0;
            int WC = eng + math + phy + chm + bio + addMath + techDraw + agric + civic;
            double PercWC = (WC/45.0) * 50.0;
            double total = (JB + PercWC);
            Console.WriteLine($"Your percentage total is {total}");
            
            static int WaecScore(string grade)
        {
            
            if(grade == "A")
            {
                return 5;
                
            }
            else if (grade == "B")
            {
                return 4;
            }
             else if (grade == "C")
            {
                return 3;
            }
             else if (grade == "D")
            {
                return 2;
            }
             else if (grade == "E")
            {
                return 1;
            }
             else if (grade == "F")
            {
                return 0;
            }
            return WaecScore(grade);
            

            
        }
        gradeRepo.Register(jambReg, jamb, english, mathematics, physics,chemistry,biology,additionalMathematics, technicalDrawing,agriculture,civicEducation,total);
        }

   
        public void CheckResult()
        {
            Console.WriteLine("Enter your Registration Number: ");
            string regNo = Console.ReadLine();
             gradeRepo.GetGrade(regNo);
           
                 Console.WriteLine("Enter 1 to Go back to the Student Menu");
                Console.WriteLine("Enter 0 to Exit");
                 bool cont = false;
            while (!cont)
            {
                
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                           cont = true;
                            break; 
                        case 0:
                           cont = true;
                            break;
                        default:
                        HookScreen();
                        break;    
                       
                    }

                
            }
        
        }
           public void Update()
        {
            Console.WriteLine("Enter Your Registration Number: ");
            string regNo = Console.ReadLine();
            var staff = studentRepo.UpdateStudent(regNo);
         
        }
           public void Check()
        {
            Console.WriteLine("Enter Your Registration Number: ");
            string regNo = Console.ReadLine();
            var staff = studentRepo.GetStudentDetails(regNo);
         
        }
                
        public void HookScreen()
        {
            Console.WriteLine("Invalid Entry\n Enter any key to continue:");
            Console.ReadKey();
        }
         public void HookScreen1()
        {
            Console.WriteLine("Enter any key to continue:");
            Console.ReadKey();
        }
    }
        
