using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.Domain.Entities;

namespace VKR.DataAccess.Configuration
{
    public class FriendsGroupConfiguration : IEntityTypeConfiguration<FriendsGroup>
    {
        public void Configure(EntityTypeBuilder<FriendsGroup> builder)
        {
            builder.ToTable(nameof(FriendsGroup));
            builder.HasKey(fg => fg.Id);
            builder.Property(fg => fg.Id).ValueGeneratedOnAdd();
        }
    }
}