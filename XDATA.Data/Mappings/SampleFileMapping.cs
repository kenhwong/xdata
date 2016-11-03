using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class SampleFileMapping : EntityTypeConfiguration<SampleFile>
    {
        public SampleFileMapping()
        {
            ToTable("SampleFiles");
            HasKey(sf => sf.UID).Property(sf => sf.UID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
