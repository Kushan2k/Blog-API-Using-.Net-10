using learn.Models;
using Microsoft.EntityFrameworkCore;

namespace learn.Context;


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<User> Users { get; set; }
}