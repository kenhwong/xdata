using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class CoverFileMapping : EntityTypeConfiguration<CoverFile>
    {
        public CoverFileMapping()
        {
            ToTable("CoverFiles");
            HasKey(cf => cf.UID).Property(cf => cf.UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
