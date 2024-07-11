using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class PasswordTypeConfiguration : IEntityTypeConfiguration<PasswordType>
    {
        private readonly List<PasswordType> _types = [
            new PasswordType() { Name = "Email" }, 
            new PasswordType() { Name = "Site" }
        ];
        public void Configure(EntityTypeBuilder<PasswordType> builder)
        {
            foreach (var type in _types) builder.HasData(type);
        }
    }
}