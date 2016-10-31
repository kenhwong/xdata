using System.Data.Entity.ModelConfiguration;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class StarMapping : EntityTypeConfiguration<Star>
    {
        public StarMapping()
        {
            ToTable("Stars");
            HasKey(s => s.UID);
            HasRequired(s => s.S_AvatarFiles).WithRequiredPrincipal(af => af.AF_Star);
        }
    }
}
