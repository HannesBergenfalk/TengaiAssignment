using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengaiAssignment.Database
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string RoleTitle { get; set; }
        public string RoleDescription { get; set; }
        public string Company { get; set; } // would become refernce in a compleate system
        public DateTime StartDate { get; set; }
        public ICollection<Focus> AssignmentFoci { get; set; }
        public ICollection<CandidateAssignment> Candidates { get; set; }
    }
}
