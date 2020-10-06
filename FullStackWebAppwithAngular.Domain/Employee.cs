using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackWebAppwithAngular.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeMobile { get; set; }
        public string EmployeeEmail { get; set; }
        public string Department { get; set; }
        public string ImageURL { get; set; }
        public DateTime EmployeeRegisteredDate { get; set; }

    }
}
