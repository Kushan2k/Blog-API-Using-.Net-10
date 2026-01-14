namespace learn.Data;

using learn.Models;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<User> Users { get; set; }
}