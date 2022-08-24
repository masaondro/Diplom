using Microsoft.EntityFrameworkCore;
using VKR.DataAccess.Configuration;
using VKR.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VKR.DataAccess
{
    /// <summary>
    /// Базовый контекст приложения
    /// </summary>
    public class BaseDbContext : IdentityDbContext<ApplicationUser>
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new FriendsGroupConfiguration());
            modelBuilder.ApplyConfiguration(new MissionConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInGroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileMissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileSectionConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}