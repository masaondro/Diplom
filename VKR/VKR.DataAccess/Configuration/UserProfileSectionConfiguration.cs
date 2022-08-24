using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.Domain.Entities;

namespace VKR.DataAccess.Configuration
{
    public class UserProfileSectionConfiguration: IEntityTypeConfiguration<UserProfileSection>
    {
        public void Configure(EntityTypeBuilder<UserProfileSection> builder)
        {
            builder.ToTable(nameof(UserProfileSection));
            builder.HasKey(s => new {s.SectionId, s.UserProfileId});
        }

    }
}