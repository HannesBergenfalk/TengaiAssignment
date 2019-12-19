using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TengaiAssignment.Database;

namespace TengaiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly TengaiDbContext _context;

        public AssignmentsController(TengaiDbContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public IEnumerable<Assignment> GetAssignments()
        {
            return _context.Assignments.Include(a => a.Candidates);
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public IActionResult GetAssignment([FromRoute] int id)
        {
            var assignment = _context.Assignments.Where(a => a.Id == id).Include(a => a.Candidates).SingleOrDefault();
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        // GET: api/Assignments/Candidates/5
        [HttpGet("Candidates/{id}")]
        public IActionResult GetCandidate([FromRoute] int id)
        {
            var assignment = _context.Candidates.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        // POST: api/Assignments
        [HttpPost]
        public IActionResult PostAssignment([FromBody] AssignmentData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Assignment assignment = new Assignment
            {
                Title = data.Title,
                RoleTitle = data.RoleTitle,
                RoleDescription = data.RoleDescription,
                Company = data.Company,
                StartDate = data.StartDate
            };
            _context.Assignments.Add(assignment);
            _context.SaveChanges();

            return CreatedAtAction("GetAssignment", new { id = assignment.Id }, assignment);
        }
        // POST: api/Assignments
        [HttpPost("candidates")]
        public IActionResult PostCandidate([FromBody] CandidateData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Candidate candidate = new Candidate
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email
            };
            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }
        // PUT: api/Assignments/assign/5/2
        [HttpPut("assign/{aId}/{cId}")]
        public IActionResult AssignmentCandidate([FromRoute] int aId, [FromRoute] int cId, [FromBody] double? score)
        {
            if (!_context.Assignments.Any(a => a.Id == aId) || !_context.Candidates.Any(c => c.Id == cId))
            {
                return BadRequest();
            }
            var ca = _context.CandidateAssignments.Find(aId, cId);
            if(ca == null)
            {
                _context.CandidateAssignments.Add(new CandidateAssignment
                {
                    AssignmentId = aId,
                    CandidateId = cId,
                    Score = score
                });
            }
            else
            {
                ca.Score = score;
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}