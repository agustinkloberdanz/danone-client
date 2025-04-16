using Microsoft.EntityFrameworkCore;
using danone_client.Models;
using danone_client.Models.Entities;
using danone_client.Repositories;

namespace danone_client.Models;
public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }


}
