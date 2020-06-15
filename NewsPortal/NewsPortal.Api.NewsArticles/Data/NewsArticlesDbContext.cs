using Microsoft.EntityFrameworkCore;

namespace NewsPortal.Api.NewsArticles.Data
{
    public class NewsArticlesDbContext: DbContext
    {
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<NewsArticleSource> NewsArticleSources { get;set; }

        public NewsArticlesDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsArticleSource>()
                .HasMany(c => c.NewsArticles)
                .WithOne(e => e.Source);
        }
    }
}