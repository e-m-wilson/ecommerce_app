using System;
using main.Domain;
using Microsoft.EntityFrameworkCore;

namespace main.Repository;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set ; }
    public DbSet<Activity> Activities { get; set; }
}
