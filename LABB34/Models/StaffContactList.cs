using System;
using System.Collections.Generic;

namespace LABB34.Models
{
    public partial class StaffContactList
    {
        public int StaffContactId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string SocialSecufrityNumber { get; set; } = null!;
        public int? FkStaffId { get; set; }
        public string Adress { get; set; } = null!;
        public string? Startdate { get; set; }

        public virtual staff? FkStaff { get; set; }
    }
}
