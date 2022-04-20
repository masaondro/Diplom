using Microsoft.EntityFrameworkCore;
using VKR.DataAccess;

namespace VKR.Migrations
{
    public class MigrationDbContext : BaseDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        {
            
        }
    }
}