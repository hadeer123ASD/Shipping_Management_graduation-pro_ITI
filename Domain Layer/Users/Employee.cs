using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Layer.Users
{
    public class Employee
    {
        public int Id { get; set; }

        public string EmployeeCode { get; set; }

        public int DepartmentId { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }
    }
}
