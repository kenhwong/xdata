using System.Data.Entity.ModelConfiguration;
using XDATA.Data;

namespace XDATA.Data.Mappings
{
    public class VideoFileMapping : EntityTypeConfiguration<VideoFile>
    {
        public VideoFileMapping()
        {
            ToTable("VideoFiles");
            HasKey(vf => vf.UID);
        }
    }
}
