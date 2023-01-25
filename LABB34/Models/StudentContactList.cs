using System;
using System.Collections.Generic;

namespace LABB34.Models
{
    public partial class StudentContactList
    {
        public int StudentContactId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int? FkStudentId { get; set; }
        public string Adress { get; set; } = null!;

        public virtual Student? FkStudent { get; set; }
    }
}
