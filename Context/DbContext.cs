using learn.Models;
using Microsoft.EntityFrameworkCore;

namespace learn.Context;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; }
}