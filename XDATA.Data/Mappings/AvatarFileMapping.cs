using System.Data.Entity.ModelConfiguration;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class AvatarFileMapping : EntityTypeConfiguration<AvatarFile>
    {
        public AvatarFileMapping()
        {
            ToTable("AvatarFiles");
            HasKey(af => af.UID);
        }
    }
}
