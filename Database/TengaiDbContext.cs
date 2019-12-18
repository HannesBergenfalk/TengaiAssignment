using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TengaiAssignment.Database
{
    public class TengaiDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateAssignment> CandidateAssignments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database=TengaiAssignment;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateAssignment>().HasKey(ca => new
            {
                ca.CandidateId,
                ca.AssignmentId
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
