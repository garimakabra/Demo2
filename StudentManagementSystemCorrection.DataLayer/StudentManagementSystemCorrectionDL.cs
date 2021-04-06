using StudentManagementSystemCorrection.Entity;
using Microsoft.Office.Interop.Excel;
using _Excel=Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace StudentManagementSystemCorrection.DataLayer
{
    public class StudentManagementSystemCorrectionDL
    {
        static int index = 2;
       
        public void EnterCollegeDataIntoExcelFile(College college)
        {
            string path = @"C:\Users\jsk\Documents/Demo.xlsx";
            _Application excel = new Application();
            Workbook wb=excel.Workbooks.Open(path);
            Worksheet ws=wb.Worksheets["Sheet1"];
            ws.Cells[1, 1].Value2 = "College Id";
            ws.Cells[1, 2].Value2 = "College Name";
            ws.Cells[1, 3].Value2 = "College Location";
            ws.Cells[1, 4].Value2 = "College CutOfPercentage";
            ws.Cells[1, 5].Value2 = "Available seats";
            ws.Cells[index, 1].Value2 = college.CollegeId;
            ws.Cells[index, 2].Value2 = college.CollegeName;
            ws.Cells[index, 3].Value2 = college.Location;
            ws.Cells[index, 4].Value2 = college.CutOfPercentange;
            ws.Cells[index, 5].Value2 = college.NumberOfSeats;
            index++;
            wb.Save();
            wb.Close();
        }

        public List<College> RetriveDataFromExcel()
        {
            string path = @"C:\Users\jsk\Documents/Demo.xlsx";
            _Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(path);
            Worksheet ws = wb.Worksheets["Sheet1"];
            _Excel.Range range = ws.UsedRange;
            int rowCount = range.Rows.Count;
            List<College> college = new List<College>();
            for(int i = 2; i <= rowCount; i++)
            {
                College tempCollege = new College();
                tempCollege.CollegeId =range.Cells[i,1].Value2;
                tempCollege.CollegeName = range.Cells[i, 2].Value2;
                tempCollege.Location = range.Cells[i, 3].Value2;
                tempCollege.CutOfPercentange = (int)range.Cells[i, 4].Value2;
                tempCollege.NumberOfSeats = (int)range.Cells[i, 5].Value2;
                college.Add(tempCollege);
            }
            wb.Close();
            return college;
        }

        public void UpdateCollegeDataIntoExcelFile(College college, List<College> colleges)
        {
            string path = @"C:\Users\jsk\Documents/Demo.xlsx";
            _Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(path);
            Worksheet ws = wb.Worksheets["Sheet1"];
            int i = 2;
            foreach (College clg in colleges)
            {
                if (clg == college)
                {
                    ws.Cells[i, 1].Value2 = college.CollegeId;
                    ws.Cells[i, 2].Value2 = college.CollegeName;
                    ws.Cells[i, 3].Value2 = college.Location;
                    ws.Cells[i, 4].Value2 = college.CutOfPercentange;
                    ws.Cells[i, 5].Value2 = --college.NumberOfSeats;
                }
                i++;
            }
            wb.Save();
            wb.Close();
        }
    }
}
