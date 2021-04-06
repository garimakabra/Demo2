using StudentManagementSystemCorrection.CustomException;
using StudentManagementSystemCorrection.DataLayer;
using StudentManagementSystemCorrection.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemCorrection.BuisnessLayer
{
    public class StudentManagementSystemCorrectionBL
    {
        public bool VarifyLoginInfo(string user,string passWord)
        {
            bool isVerified = true;
            try
            {
                if (!(user == "Admin" || user == "Student"))
                {
                    throw new InValidLoginIdException("You entered Invalid User Id");
                }
                if(user == "Admin")
                {
                    if (passWord != "Admin")
                    {
                        throw new InValidPassWordException("You entered Invalid Password For Admin!!!!LogIn Again");
                    }
                }
                else if (user == "Student")
                {
                    if (passWord != "Student")
                    {
                        throw new InValidPassWordException("You entered Invalid Password For Student!!!!LogIn Again");
                    }
                }
            }
            catch(InValidLoginIdException ex)
            {
                Console.WriteLine(ex.Message);
                isVerified = false;
                return isVerified;
            }
            catch (InValidPassWordException ex)
            {
                Console.WriteLine(ex.Message);
                isVerified = false;
                return isVerified;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isVerified = false;
                return isVerified;
            }
            return isVerified;
        }

        public void AcceptCollegeDetail(College college)
        {
            StudentManagementSystemCorrectionDL objDL = new StudentManagementSystemCorrectionDL();
            string result = "";

            objDL.EnterCollegeDataIntoExcelFile(college);
        }
        public College AcceptStudentDetail(Student student,string clgId)
        {
            StudentManagementSystemCorrectionDL objDL = new StudentManagementSystemCorrectionDL();
            List<College> colleges = new List<College>();
            colleges = objDL.RetriveDataFromExcel();
            College temp = null;
            foreach(College clg in colleges)
            {
                if (clg.CollegeId == clgId)
                {
                    if (student.StudentPercentage >= clg.CutOfPercentange && clg.NumberOfSeats>=1)
                    {
                        temp = clg;
                        objDL.UpdateCollegeDataIntoExcelFile(clg,colleges);
                    }
                }
            }
            return temp;
        }
        public List<College> DisplayAllCollegeInformation()
        {
            StudentManagementSystemCorrectionDL objDL = new StudentManagementSystemCorrectionDL();
            List<College> colleges = new List<College>();
            colleges=objDL.RetriveDataFromExcel();
            return colleges;
        }

        public Student DisplayDataOfEnteredStudentId(string stuId, List<Student>students)
        {
            Student temp = null;
            foreach(Student stu in students)
            {
                if (stuId == stu.StudentId)
                {
                    temp = stu;
                }
            }
            return temp;
        }
    }
}
