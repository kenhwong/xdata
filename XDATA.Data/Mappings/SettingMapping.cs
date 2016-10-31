using System.Data.Entity.ModelConfiguration;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class SettingMapping : EntityTypeConfiguration<Setting>
    {
        public SettingMapping()
        {
            ToTable("Settings");
            HasKey(sf => sf.UID);
            Property(x => x.Key).IsRequired().HasMaxLength(100);
            Property(x => x.Notes).HasMaxLength(250);
        }
    }
}
