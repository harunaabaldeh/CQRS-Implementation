using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CQRS.Models
{
    public partial class ListOfSchool
    {
        public int Id { get; set; }
        [DisplayName("School Name")]
        public string SchooName { get; set; } = null!;
        public string Region { get; set; } = null!;
        [DisplayName("Schoo Number")]
        public string SchooNumber { get; set; } = null!;
        [DisplayName("School Type")]
        public string SchoolType { get; set; } = null!;
    }
}
