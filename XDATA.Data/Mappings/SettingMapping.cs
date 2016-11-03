using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class SettingMapping : EntityTypeConfiguration<Setting>
    {
        public SettingMapping()
        {
            ToTable("Settings");
            HasKey(s => s.UID).Property(s => s.UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.Key).IsRequired().HasMaxLength(100);
            Property(s => s.Notes).HasMaxLength(250);
        }
    }
}
