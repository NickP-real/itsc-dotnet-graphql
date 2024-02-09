using Microsoft.EntityFrameworkCore;

namespace blog_api.Models;

public class BlogDbContext : DbContext
{
  public DbSet<Article> Articles { get; set; }
  public DbSet<Comment> Comments { get; set; }

  public BlogDbContext(DbContextOptions<BlogDbContext> option) : base(option) { }
}
