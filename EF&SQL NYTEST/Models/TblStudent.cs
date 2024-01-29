using System;
using System.Collections.Generic;

namespace EF_SQL_NYTEST.Models
{
    public partial class TblStudent
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string Personnummer { get; set; } = null!;
        public int Age { get; set; }
        public string Class { get; set; } = null!;
    }
}
