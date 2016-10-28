using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

//http://www.cnblogs.com/lsxqw2004/archive/2015/08/07/4701979.html
namespace XDATA.Model
{
    public class MappingMovie : EntityTypeConfiguration<Model.Movie>
    {
        public MappingMovie()
        {
            ToTable("Movies");
            HasKey(m => m.M_UID);
            Property(m => m.M_UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.M_ReleaseID).IsRequired().HasMaxLength(32).IsUnicode(true);
            Property(m => m.M_ReleaseTitle).IsRequired().HasMaxLength(256).IsUnicode(true);
            Property(m => m.M_ReleaseDate).IsRequired();
            HasMany(m => m.M_SampleFiles).WithRequired(sf => sf.SF_Movie).HasForeignKey(sf => sf.SF_M_UID);
            HasMany(m => m.M_Stars).WithMany(s => s.S_Movies).Map(msmap => msmap.ToTable("Movie_Star_Mapping"));
        }
    }

    public class MappingSampleFile:EntityTypeConfiguration<Model.SampleFile>
    {
        public MappingSampleFile()
        {
            ToTable("SampleFiles");
            HasKey(sf => sf.SF_UID);
        }
    }

    public class MappingStar:EntityTypeConfiguration<Model.Star>
    {
        public MappingStar()
        {
            ToTable("Stars");
            HasKey(s=> s.S_UID);
            HasRequired(s => s.S_AvatarFiles).WithRequiredPrincipal(af => af.AF_Star);
        }
    }

    public class MappingAvatarFile:EntityTypeConfiguration<Model.AvatarFile>
    {
        public MappingAvatarFile()
        {
            ToTable("AvatarFiles");
            HasKey(af => af.AF_S_UID);
        }
    }

}
