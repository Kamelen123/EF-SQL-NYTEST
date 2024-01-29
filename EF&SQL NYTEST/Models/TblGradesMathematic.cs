using System;
using System.Collections.Generic;

namespace EF_SQL_NYTEST.Models
{
    public partial class TblGradesMathematic
    {
        public int? StudentId { get; set; }
        public string? Mathematics1 { get; set; }
        public string? Mathematics2 { get; set; }
        public string? Mathematics3 { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual TblEmployee? Employee { get; set; }
        public virtual TblStudent? Student { get; set; }
    }
}
