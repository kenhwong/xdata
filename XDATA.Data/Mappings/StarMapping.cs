using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class StarMapping : EntityTypeConfiguration<Star>
    {
        public StarMapping()
        {
            ToTable("Stars");
            HasKey(s => s.UID).Property(s => s.UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(s => s.S_AvatarFiles).WithRequiredPrincipal(af => af.AF_Star);
        }
    }
}
