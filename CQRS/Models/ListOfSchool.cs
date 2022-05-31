using System;
using System.Collections.Generic;

namespace CQRS.Models
{
    public partial class ListOfSchool
    {
        public int Id { get; set; }
        public string SchooName { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string SchooNumber { get; set; } = null!;
        public string SchoolType { get; set; } = null!;
    }
}
