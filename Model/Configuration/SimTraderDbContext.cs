using Microsoft.EntityFrameworkCore;

namespace Model.Configuration;

public class SimTraderDbContext : DbContext{
    
    public SimTraderDbContext(DbContextOptions options) : base(options){
    }

    public DbSet<Type> Type{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder){
        
    }
}