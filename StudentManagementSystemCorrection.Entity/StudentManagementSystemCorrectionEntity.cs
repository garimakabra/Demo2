using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemCorrection.Entity
{
     public class StudentManagementSystemCorrectionEntity
    {
    }
    public class College
    {
        public string CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string Location { get; set; }
        public int NumberOfSeats { get; set; }
        public int CutOfPercentange { get; set; }
    }
    public class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public College college { get; set; }
        public int StudentPercentage { get; set; }
    }
}
