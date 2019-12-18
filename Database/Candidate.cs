using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TengaiAssignment.Database
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<CandidateAssignment> Assignments { get; set; }
    }
}
