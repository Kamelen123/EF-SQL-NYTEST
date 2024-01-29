using System;
using System.Collections.Generic;

namespace EF_SQL_NYTEST.Models
{
    public partial class TblGradesEnglish
    {
        public int? StudentId { get; set; }
        public string? English1 { get; set; }
        public string? English2 { get; set; }
        public string? English3 { get; set; }
        public int? EmployeId { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual TblEmployee? Employe { get; set; }
        public virtual TblStudent? Student { get; set; }
    }
}
