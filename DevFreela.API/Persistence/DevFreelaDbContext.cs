using DevFreela.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Skill>(e =>
                {
                    e.HasKey(s => s.Id);
                });

            builder
                .Entity<UserSkill>(e =>
                {
                    e.HasKey(s => s.Id);

                    e.HasOne(s => s.Skill)
                        .WithMany(us => us.UserSkills)
                        .HasForeignKey(s =>s.IdSkill)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<ProjectComment>(e =>
                {
                    e.HasKey(x=> x.Id);

                    e.HasOne(e => e.Project)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(x=> x.IdProject)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<User>(e => 
                {
                    e.HasKey(x => x.Id);

                    e.HasMany(x=> x.Skills)
                        .WithOne(x=> x.User)
                        .HasForeignKey(x=> x.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<Project>(e =>
                {
                    e.HasKey(x => x.Id);

                    e.HasOne(p => p.Freelancer)
                        .WithMany(f => f.FreelanceProjects)
                        .HasForeignKey(f => f.IdFreelancer)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.Client)
                       .WithMany(f => f.OwnedProjects)
                       .HasForeignKey(f => f.IdClient)
                       .OnDelete(DeleteBehavior.Restrict);
                });


            base.OnModelCreating(builder);
        }
    }
}
