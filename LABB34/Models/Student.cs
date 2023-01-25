using System;
using System.Collections.Generic;

namespace LABB34.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentContactLists = new HashSet<StudentContactList>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Class { get; set; } = null!;
        public string Socialsecuritynumber { get; set; } = null!;

        public virtual ICollection<StudentContactList> StudentContactLists { get; set; }
    }
}
