using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class AvatarFileMapping : EntityTypeConfiguration<AvatarFile>
    {
        public AvatarFileMapping()
        {
            ToTable("AvatarFiles");
            HasKey(af => af.UID).Property(af => af.UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
