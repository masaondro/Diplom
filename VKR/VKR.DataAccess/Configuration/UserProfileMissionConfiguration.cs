using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.Domain.Entities;

namespace VKR.DataAccess.Configuration
{
    public class UserProfileMissionConfiguration: IEntityTypeConfiguration<UserProfileMission>
    {
        public void Configure(EntityTypeBuilder<UserProfileMission> builder)
        {
            builder.ToTable(nameof(UserProfileMission));
            builder.HasKey(s => new {s.MissionId, s.UserProfileId});
        }
    }
}