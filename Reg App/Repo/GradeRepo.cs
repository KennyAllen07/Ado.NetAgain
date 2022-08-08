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
    public class GradeRepo
    {
        string connect = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public string JambReg { get; set; }


        private TextWriter textWriter;
        List<Grade> grades;

        public void AddGrade(Grade grade)
        {
            MySqlConnection Conn = null;
            try
            {
                Conn = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"insert into Grade(RegNo, Jamb, English, Mathematics, Physics, Chemistry, Biology, AdditionalMathematics, TechnicalDrawing, Agriculture, CivicEducation, Total) value('{grade.JambReg}', '{grade.Jamb}', '{grade.English}', '{grade.Mathematics}', '{grade.Physics}', '{grade.Chemistry}', '{grade.Biology}', '{grade.AdditionalMathematics}', '{grade.TechnicalDrawing}', '{grade.Agriculture}', '{grade.CivicEducation}', '{grade.Total}')", Conn);
                Conn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Grades Added Successfully");
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

        // public GradeRepo()
        // {
        //     grades = new List<Grade>();
        //     string path = @"C:\Users\Kenny Allen\Desktop\Reg App - Copy\Grade.txt";
        //     if (File.Exists(path))
        //     {
        //         var lines = File.ReadAllLines(@"C:\Users\Kenny Allen\Desktop\Reg App - Copy\Grade.txt");
        //         foreach (var line in lines)
        //         {
        //             var grade = Grade.FormatLine(line);
        //             grades.Add(grade);
        //         }
        //     }  
        // }     




        public void Register(string jambReg, int jamb, string english, string mathematics, string physics, string chemistry, string biology, string additionalMathematics, string technicalDrawing, string agriculture, string civicEducation, double total)
        {


            var grade = new Grade(jambReg, jamb, english, mathematics, physics, chemistry, biology, additionalMathematics, technicalDrawing, agriculture, civicEducation, total);
            AddGrade(grade);
            // TextWriter writer = new StreamWriter(@"C:\Users\Kenny Allen\Desktop\Reg App - Copy\Grade.txt", true);
            // writer.WriteLine(grade.ToString());
            // writer.Close();
            //Console.WriteLine("Grades added successfully");

            //RefreshFile();


        }

        public void PrintGrades(string regNo)
        {
            foreach (var grade in grades)
            {
                if (grade.JambReg == regNo)
                {
                    Console.WriteLine("///////////////");
                    Console.WriteLine($"Jamb: {grade.Jamb}");
                    Console.WriteLine($"English: {grade.English}");
                    Console.WriteLine($"Mathematics: {grade.Mathematics}");
                    Console.WriteLine($"Physics: {grade.Physics}");
                    Console.WriteLine($"Chemistry: {grade.Chemistry}");
                    Console.WriteLine($"Biology: {grade.Biology}");
                    Console.WriteLine($"Additional Mathematics: {grade.AdditionalMathematics}");
                    Console.WriteLine($"Technical Drawing: {grade.TechnicalDrawing}");
                    Console.WriteLine($"Agriculture: {grade.Agriculture}");
                    Console.WriteLine($"Civic Education: {grade.CivicEducation}");
                    Console.WriteLine($"Total: {grade.Total}%");
                    Console.WriteLine("///////////////");

                }



            }

        }
        public void PrintGradesStaff()
        {
            foreach (var grade in grades)
            {
                Console.WriteLine(grade);
            }

        }
        public Student GetStudentResultStaff(string regNo)
        {

            foreach (var grade in grades)
            {
                if (grade.JambReg == regNo)
                {
                    Console.WriteLine("///////////////");
                    Console.WriteLine($"Registration Number: {grade.JambReg}");
                    Console.WriteLine($"Jamb: {grade.Jamb}");
                    Console.WriteLine($"English: {grade.English}");
                    Console.WriteLine($"Mathematics: {grade.Mathematics}");
                    Console.WriteLine($"Physics: {grade.Physics}");
                    Console.WriteLine($"Chemistry: {grade.Chemistry}");
                    Console.WriteLine($"Biology: {grade.Biology}");
                    Console.WriteLine($"Additional Mathematics: {grade.AdditionalMathematics}");
                    Console.WriteLine($"Technical Drawing: {grade.TechnicalDrawing}");
                    Console.WriteLine($"Agriculture: {grade.Agriculture}");
                    Console.WriteLine($"Civic Education: {grade.CivicEducation}");
                    Console.WriteLine($"Total: {grade.Total}");
                    Console.WriteLine("///////////////");
                }
            }

            return null;
        }

        public void GetAllStudentResult()
        {
            var grades = ListGrade();
            foreach (var grade in grades)
            {
                if (grade != null)
                {
                    Console.WriteLine("///////////////");
                    Console.WriteLine($"Registration Number: {grade.JambReg}");
                    Console.WriteLine($"Jamb: {grade.Jamb}");
                    Console.WriteLine($"English: {grade.English}");
                    Console.WriteLine($"Mathematics: {grade.Mathematics}");
                    Console.WriteLine($"Physics: {grade.Physics}");
                    Console.WriteLine($"Chemistry: {grade.Chemistry}");
                    Console.WriteLine($"Biology: {grade.Biology}");
                    Console.WriteLine($"Additional Mathematics: {grade.AdditionalMathematics}");
                    Console.WriteLine($"Technical Drawing: {grade.TechnicalDrawing}");
                    Console.WriteLine($"Agriculture: {grade.Agriculture}");
                    Console.WriteLine($"Civic Education: {grade.CivicEducation}");
                    Console.WriteLine($"Total: {grade.Total}%");
                    Console.WriteLine("///////////////");
                }

            }

        }
        public Grade GetGrade(string regNo)
        {
            Grade grade = null;
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            var sql = "select RegNo,Jamb,English,Mathematics,Physics,Chemistry,Biology,AdditionalMathematics,TechnicalDrawing,Agriculture,CivicEducation,Total from grade where RegNo = '" + regNo + "'";
            MySqlCommand command = new MySqlCommand(sql, Conn);
            Conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"RegNo: {(reader["RegNo"])}");
                Console.WriteLine($"Jamb: {(reader["Jamb"])}");
                Console.WriteLine($"English: {(reader["English"])}");
                Console.WriteLine($"Mathematics: {(reader["Mathematics"])}");
                Console.WriteLine($"Physics: {(reader["Physics"])}");
                Console.WriteLine($"Chemistry: {(reader["Chemistry"])}");
                Console.WriteLine($"Biology: {(reader["Biology"])}");
                Console.WriteLine($"Additional Mathematics: {(reader["AdditionalMathematics"])}");
                Console.WriteLine($"Technical Drawing: {(reader["TechnicalDrawing"])}");
                Console.WriteLine($"Agriculture: {(reader["Agriculture"])}");
                Console.WriteLine($"Civic Education: {(reader["CivicEducation"])}");
                Console.WriteLine($"Total: {(reader["Total"])}%");

                Conn.Close();
                return grade;
            }
            else
            {
                return null;
            }

        }
           public Grade GetGradeUpdate(string regNo)
        {
            Grade grade = null;
            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            var sql = "select RegNo,Jamb,English,Mathematics,Physics,Chemistry,Biology,AdditionalMathematics,TechnicalDrawing,Agriculture,CivicEducation,Total from grade where RegNo = '" + regNo + "'";
            MySqlCommand command = new MySqlCommand(sql, Conn);
            Conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string RegNo = $"{(reader["RegNo"])}";
                int Jamb = int.Parse($"{(reader["Jamb"])}");
                string English = $"{(reader["English"])}";
                string maths = $"{(reader["Mathematics"])}";
                string physics = $"{(reader["Physics"])}";
                string chemistry = $"{(reader["Chemistry"])}";
                string biology = $"{(reader["Biology"])}";
                string AdditionalMathematics = $"{(reader["AdditionalMathematics"])}";
                string TechnicalDrawing = $"{(reader["TechnicalDrawing"])}";
                string Agriculture = $"{(reader["Agriculture"])}";
                string Civic = $"{(reader["CivicEducation"])}";
                double Total = double.Parse($"{(reader["Total"])}");

                grade = new Grade(RegNo, Jamb, English, maths, physics, chemistry, biology, AdditionalMathematics, TechnicalDrawing, Agriculture, Civic, Total);
                Conn.Close();
                return grade;
            }
            else
            {
                return null;
            }

        }
        public Grade UpdateGrade(string regNo)
        {
            string StregNo = regNo;
            var grade = GetGradeUpdate(regNo);
            if (grade != null)
            {
                Console.WriteLine("Enter Your Jamb Score");
                int jamb;
                while (!int.TryParse(Console.ReadLine(), out jamb))
                {
                    Console.WriteLine("Enter your Jamb Score: ");
                }

                Console.WriteLine("Enter your WAEC Grades");
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
                double JB = (jamb / 400.0) * 50.0;
                int WC = eng + math + phy + chm + bio + addMath + techDraw + agric + civic;
                double PercWC = (WC / 45.0) * 50.0;
                double total = (JB + PercWC);
                Console.WriteLine($"Your percentage total is {total}");

                static int WaecScore(string grade)
                {

                    if (grade == "A")
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
                MySqlConnection Conn = null;
                Conn = new MySqlConnection(connect);
                MySqlCommand command = new MySqlCommand($"update Grade set `Jamb` = '{jamb}', `English` = '{english}', `Mathematics` = '{mathematics}', `Physics` = '{physics}', `Chemistry` = '{chemistry}', `Biology` = '{biology}', `AdditionalMathematics` = '{additionalMathematics}', `TechnicalDrawing` = '{technicalDrawing}', `Agriculture` = '{agriculture}', `CivicEducation` = '{civicEducation}', `Total` = '{total}' where `RegNo` = '{regNo}' ", Conn);
                Conn.Open();
                command.ExecuteNonQuery();
                Conn.Close();
                Console.WriteLine($"Your Grades have been Successfully Updated.");
            }
            return null;
        }
        public List<Grade> ListGrade()
        {
            List<Grade> grades = new List<Grade>();

            MySqlConnection Conn = null;
            Conn = new MySqlConnection(connect);
            int count = 0;
            var sql = "select * from grade";
            var query = "select count(*)from grade";
            MySqlCommand command = new MySqlCommand(sql, Conn);
            MySqlCommand countCommand = new MySqlCommand(query, Conn);
            Conn.Open();
            using (countCommand)
            {
                count = Convert.ToInt32(countCommand.ExecuteScalar());
            }
            MySqlDataReader reader = command.ExecuteReader();

            if (count != 0)
            {
                for (var i = 0; i < count; i++)
                {
                    reader.Read();
                    string RegNo = $"{(reader["RegNo"])}";
                    int jamb = int.Parse($"{(reader["Jamb"])}");
                   string English = $"{(reader["English"])}";
                    string Maths = $"{(reader["Mathematics"])}";
                    string physics = $"{(reader["Physics"])}";
                    string chemistry = $"{(reader["Chemistry"])}";
                    string biology = $"{(reader["Biology"])}";
                    string addmths = $"{(reader["AdditionalMathematics"])}";
                    string td = $"{(reader["TechnicalDrawing"])}";
                    string agric = $"{(reader["Agriculture"])}";
                    string civic = $"{(reader["CivicEducation"])}";
                    double total = double.Parse($"{(reader["Total"])}");




                    var grade = new Grade(RegNo, jamb, English, Maths, physics, chemistry, biology, addmths, td, agric, civic, total);
                    grades.Add(grade);


                }
                return grades;
            }
            else
            {
                return null;
            }

        }
           public Grade DeleteGrade(string delGrade)
        {
            string regNo = delGrade;
            
            var grade =  GetGradeUpdate(regNo);
            if(grade != null)
            {
                Console.WriteLine($"You are about to delete this grade profile of {grade.JambReg}. Enter 1 to delete the profile or 0 to keep the profile.");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid Input Enter 1 or 0");

                }
                if (option == 1)
                {
                MySqlConnection Conn = null;
                Conn = new MySqlConnection(connect);
                var sql = "delete from grade where RegNo = '" + regNo + "'";
                MySqlCommand command = new MySqlCommand(sql,Conn);
                Conn.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"Grade Profile Successfully Deleted");
                Conn.Close();
                }
                else if (option == 0)
                {
                    return null;
                }
            }
         return null;
        }
        private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Grade.txt");
            foreach (Grade grade in grades)
            {
                writer.WriteLine(grade);
            }
            writer.Flush();
            writer.Close();
        }


    }

}
