using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class MovieMapping : EntityTypeConfiguration<Movie>
    {
        public MovieMapping()
        {
            ToTable("Movies");
            HasKey(m => m.UID).Property(m => m.UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.M_ReleaseID).IsRequired().HasMaxLength(32).IsUnicode(true);
            Property(m => m.M_ReleaseTitle).IsRequired().HasMaxLength(256).IsUnicode(true);
            Property(m => m.M_ReleaseDate).IsRequired();
            HasMany(m => m.M_SampleFiles).WithRequired(sf => sf.SF_Movie).HasForeignKey(sf => sf.SF_M_UID);
            HasMany(m => m.M_Stars).WithMany(s => s.S_Movies).Map(msmap => msmap.ToTable("Movie_Star_Mapping"));
            HasMany(m => m.M_VideoFiles).WithRequired(vf => vf.VF_Movie).HasForeignKey(vf => vf.VF_M_UID);
            HasRequired(m => m.M_CoverFile).WithRequiredPrincipal(cf => cf.CF_Movie);
        }
    }
}
