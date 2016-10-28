using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XDATA.Data
{
    class SampleFile : EntityBase
    {
        //public Guid SF_UID { get; set; }
        public Guid SF_M_UID { get; set; }
        public virtual Movie SF_Movie { get; set; }
        public string SF_Name { get; set; }
        public string SF_Path { get; set; }
        //public ImageFormat SF_ImageType { get; set; }
        public string SF_ImageType { get; set; }
        public ImageType SF_Type { get; set; }
        public int SF_Width { get; set; }
        public int SF_Height { get; set; }
        public int SF_Length { get; set; }

        public SampleFile()
        {
            this.UID = Guid.NewGuid();
            this.SF_Type = ImageType.SampleShot;
        }

        public SampleFile(string fullname) : this()
        {
            this.SF_Path = Path.GetDirectoryName(fullname);
            this.SF_Name = Path.GetFileName(fullname);
            this.SF_ImageType = Path.GetExtension(fullname);
        }
    }
}
