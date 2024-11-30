using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




[ApiController]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
    private readonly FreeLancerDbContext _context;

    public FreelancersController(FreeLancerDbContext context)
    {
        _context = context;
    }

    // POST: api/Freelancers
    [HttpPost]
    public async Task<ActionResult<FreelancerModel>> RegisterFreelancer([FromBody] FreelancerRegisterRequest request)
    {
        // Step 1: Create a new freelancer
        var freelancer = new FreelancerModel
        {
            Username = request.Username,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            IsArchived = false
        };

        _context.Freelancers.Add(freelancer);
        await _context.SaveChangesAsync(); // Save freelancer first to get Id

        // Step 2: Add skillsets
        if (request.Skillsets != null && request.Skillsets.Any())
        {
            foreach (var skill in request.Skillsets)
            {
                var freelancerSkillset = new FreelancerSkillsetModel
                {
                    SkillName = skill,
                    FreelancerId = freelancer.Id
                };
                _context.Skillsets.Add(freelancerSkillset);
            }
        }

        // Step 3: Add hobbies
        if (request.Hobbies != null && request.Hobbies.Any())
        {
            foreach (var hobby in request.Hobbies)
            {
                var freelancerHobby = new FreelancerHobbyModel
                {
                    HobbyName = hobby,
                    FreelancerId = freelancer.Id
                };
                _context.Hobbies.Add(freelancerHobby);
            }
        }

        // Step 4: Save the related skillsets and hobbies
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFreelancerById), new { id = freelancer.Id }, freelancer);
    }

    // GET: api/Freelancers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FreelancerModel>> GetFreelancerById(int id)
    {
        var freelancer = await _context.Freelancers
            .Include(f => f.Skillsets)
            .Include(f => f.Hobbies)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (freelancer == null)
        {
            return NotFound();
        }

        return freelancer;
    }
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<FreelancerModel>>> SearchFreelancers([FromQuery] string searchTerm)
    {
        var freelancers = await _context.Freelancers
             .Include(f => f.Skillsets)
            .Include(f => f.Hobbies)
            .Where(f => f.Username.Contains(searchTerm) || f.Email.Contains(searchTerm))
            .ToListAsync();

        return freelancers;
    }
    [HttpPut("archive/{id}")]
    public async Task<IActionResult> ArchiveFreelancer(int id)
    {
        var freelancer = await _context.Freelancers.FindAsync(id);

        if (freelancer == null)
        {
            return NotFound(new { message = "Freelancer not found" });
        }

        // Set the freelancer as archived
        freelancer.IsArchived = true;

        // Save changes to the database
        await _context.SaveChangesAsync();

        return Ok(new { message = "Freelancer archived successfully" });
    }
    [HttpPut("unarchive/{id}")]
    public async Task<IActionResult> UnarchiveFreelancer(int id)
    {
        var freelancer = await _context.Freelancers.FindAsync(id);

        if (freelancer == null)
        {
            return NotFound(new { message = "Freelancer not found" });
        }

        // Set the freelancer as unarchived
        freelancer.IsArchived = false;

        // Save changes to the database
        await _context.SaveChangesAsync();

        return Ok(new { message = "Freelancer unarchived successfully" });
    }


}

public class FreelancerRegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Skillsets { get; set; }
    public List<string> Hobbies { get; set; }
}
