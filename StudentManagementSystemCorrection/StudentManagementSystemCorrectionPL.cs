using StudentManagementSystemCorrection.BuisnessLayer;
using StudentManagementSystemCorrection.Entity;
using System;
using System.Collections.Generic;

namespace StudentManagementSystemCorrection
{
    class StudentManagementSystemCorrectionPL
    {
        static int Cid = 1000;
        static int Sid = 1000;
        List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            bool status = true;
            StudentManagementSystemCorrectionPL objPL = new StudentManagementSystemCorrectionPL();
            do
            {
                Console.WriteLine("1.Login Here");
                Console.WriteLine("2.Close The Browser");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        objPL.EnterLoginInfo();
                        break;
                    case 2:
                        Console.WriteLine("Thank You For Using Our Services.");
                        status = false;
                        break;
                }
            } while (status);
        }

        public void EnterLoginInfo()
        {
            bool status = true;
            string user = "", password = "";
            do
            {
                Console.WriteLine("Enter Your Login Id-Admin/Student");
                user = Console.ReadLine();
                Console.WriteLine("Enter Your Login PassWord");
                password = Console.ReadLine();
                StudentManagementSystemCorrectionBL objBL = new StudentManagementSystemCorrectionBL();
                status = objBL.VarifyLoginInfo(user, password);
            } while (!status);
            Console.WriteLine("You Logged In SuccessFully.");
            if (user == "Admin")
            {
                PerformAdminFunction();
            }
            else
            {
                PerformStudentFunction();
            }
        }

        public void PerformAdminFunction()
        {
            bool status = true;
            StudentManagementSystemCorrectionBL objBL = new StudentManagementSystemCorrectionBL();
            do
            {
                Console.WriteLine("1.Add colleges To Sheet");
                Console.WriteLine("2.Fetch Student data According to given ID");
                Console.WriteLine("3.Exit");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        string isContinue = "Y";
                        do
                        {
                            College college = new College();
                            college.CollegeId = "C" + ++Cid;
                            Console.WriteLine("Enter College Name:");
                            college.CollegeName = Console.ReadLine();
                            Console.WriteLine("Enter College Location:");
                            college.Location = Console.ReadLine();
                            Console.WriteLine("Enter College Cut Off Percentage:");
                            college.CutOfPercentange = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Number Of Seats Available:");
                            college.NumberOfSeats = Convert.ToInt32(Console.ReadLine());
                            objBL.AcceptCollegeDetail(college);
                            Console.WriteLine("Do You Want To add More collegs?Y/N");
                            isContinue = Console.ReadLine();
                        } while (isContinue == "Y");
                        break;
                    case 2:
                        Console.WriteLine("Enter Student Id You Want to fetch data");
                        string stuId = Console.ReadLine();
                        Student stu= objBL.DisplayDataOfEnteredStudentId(stuId, students);
                        if (stu != null)
                        {
                            Console.WriteLine(stu.StudentId+" "+stu.StudentName+" "+stu.StudentPercentage+" \n"+stu.college.CollegeId + stu.college.CollegeName + stu.college.Location);
                        }
                        break;
                    case 3:
                        Console.WriteLine("You Logged Off");
                        status = false;
                        break;
                }
            } while (status);
        }
        public void PerformStudentFunction()
        {
            StudentManagementSystemCorrectionBL objBL = new StudentManagementSystemCorrectionBL();
            List<College> colleges = new List<College>();
            colleges = objBL.DisplayAllCollegeInformation();
            foreach(College clg in colleges)
            {
                Console.WriteLine(clg.CollegeId + " " +clg.CollegeName+" "+clg.Location+" "+clg.CutOfPercentange+" "+clg.NumberOfSeats);
            }
            
            Student student = new Student();
            student.StudentId = "S" + ++Sid;
            Console.WriteLine("Enter Student Name:");
            student.StudentName = Console.ReadLine();
            Console.WriteLine("Enter Student Percentage:");
            student.StudentPercentage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter College Id");
            string clgId = Console.ReadLine();
            College college=objBL.AcceptStudentDetail(student, clgId);
            if (college == null)
            {
                Console.WriteLine("There is No College Id present Or You are not elegible");
            }
            else
            {
                student.college = college;
                students.Add(student);
            }
        }
    }
}
