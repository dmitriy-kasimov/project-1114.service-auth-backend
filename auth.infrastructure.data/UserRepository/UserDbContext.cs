using auth.infrastructure.data.UserRepository.Configurations;
using auth.infrastructure.data.UserRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace auth.infrastructure.data.UserRepository;

public class UserDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("SERVER=localhost;DATABASE=service-auth;UID=root;Password=;Pooling=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}