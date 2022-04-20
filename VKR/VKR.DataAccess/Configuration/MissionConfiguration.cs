using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.Domain.Entities;

namespace VKR.DataAccess.Configuration
{
    /// <summary>
    /// Конфигурация таблицы БД Mission
    /// </summary>
    public class MissionConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.ToTable(nameof(Mission));
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
        }
    }
}