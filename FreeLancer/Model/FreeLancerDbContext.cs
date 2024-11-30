
using Microsoft.EntityFrameworkCore;

//public class FreeLancerDbContext : DbContext
//{
//    public FreeLancerDbContext(DbContextOptions<FreeLancerDbContext> options) : base(options) { }

//    public DbSet<FreelancerModel> Freelancers { get; set; }
//    public DbSet<SkillsetModel> Skillsets { get; set; }
//    public DbSet<HobbyModel> Hobbies { get; set; }
//    public DbSet<FreelancerSkillsetModel> FreelancerSkillsets { get; set; }
//    public DbSet<FreelancerHobbyModel> FreelancerHobbies { get; set; }


//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    if(!optionsBuilder.IsConfigured)
//    {
//        optionsBuilder.UseSqllite
//    }
//}

//}
public class FreeLancerDbContext : DbContext
{
    public FreeLancerDbContext(DbContextOptions<FreeLancerDbContext> options) : base(options) { }
    public DbSet<FreelancerModel> Freelancers { get; set; }
    public DbSet<FreelancerSkillsetModel> Skillsets { get; set; }
    public DbSet<FreelancerHobbyModel> Hobbies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FreelancerModel>()
            .HasMany(f => f.Skillsets)
            .WithOne(s => s.Freelancer)
            .HasForeignKey(s => s.FreelancerId);

        modelBuilder.Entity<FreelancerModel>()
            .HasMany(f => f.Hobbies)
            .WithOne(h => h.Freelancer)
            .HasForeignKey(h => h.FreelancerId);
    }
}

