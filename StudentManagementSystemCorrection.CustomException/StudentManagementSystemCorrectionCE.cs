using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemCorrection.CustomException
{
    public class StudentManagementSystemCorrectionCE
    {
    }
    public class InValidLoginIdException:Exception
    {
        public InValidLoginIdException(string message):base( message)
        {
            
        }
    }

    public class InValidPassWordException : Exception
    {
        public InValidPassWordException(string message) : base(message)
        {

        }
    }
}
