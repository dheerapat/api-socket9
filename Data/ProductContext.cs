using Microsoft.EntityFrameworkCore;
using prod.Models;
using NT.Common.DataAccess.Context;

namespace prod.Data;

public class prodContext : EntityContextBase<prodContext>
{
    //private readonly IConfiguration configuration;
    public prodContext(DbContextOptions<prodContext> options) : base(options)
        {
            //this.configuration = configuration;
        }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
}