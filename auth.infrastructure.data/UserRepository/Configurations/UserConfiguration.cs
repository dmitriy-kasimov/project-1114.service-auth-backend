using auth.infrastructure.data.UserRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auth.infrastructure.data.UserRepository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Name);
        builder.Property(entity => entity.PassHash);
    }
}