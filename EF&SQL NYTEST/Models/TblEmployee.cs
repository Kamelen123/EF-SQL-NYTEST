using System;
using System.Collections.Generic;

namespace EF_SQL_NYTEST.Models
{
    public partial class TblEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string Position { get; set; } = null!;
    }
}
