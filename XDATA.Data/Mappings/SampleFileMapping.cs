using System.Data.Entity.ModelConfiguration;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class SampleFileMapping : EntityTypeConfiguration<SampleFile>
    {
        public SampleFileMapping()
        {
            ToTable("SampleFiles");
            HasKey(sf => sf.UID);
        }
    }
}
