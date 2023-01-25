using System;
using System.Collections.Generic;

namespace LABB34.Models
{
    public partial class Grade
    {
        public int GradesId { get; set; }
        public string Grades { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Subject { get; set; } = null!;
        public int FkStudentId { get; set; }
        public int FkStaffId { get; set; }

        public virtual staff FkStaff { get; set; } = null!;
        public virtual Student FkStudent { get; set; } = null!;
    }
}
