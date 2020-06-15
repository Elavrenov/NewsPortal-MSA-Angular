using Microsoft.EntityFrameworkCore;

namespace NewsPortal.Api.Publishers.Data
{
    public class PublishersDbContext: DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }

        public PublishersDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}