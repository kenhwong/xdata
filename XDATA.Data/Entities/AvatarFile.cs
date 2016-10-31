using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XDATA.Data
{
    public class AvatarFile : EntityBase
    {
        //public Guid AF_S_UID { get; set; }
        public virtual Star AF_Star { get; set; }
        public string AF_Name { get; set; }
        public string AF_Path { get; set; }
        //public ImageFormat AF_ImageType { get; set; }
        public string AF_ImageType { get; set; }
        public ImageType AF_Type { get; set; }
        public int AF_Width { get; set; }
        public int AF_Height { get; set; }
        public int AF_Length { get; set; }

        public AvatarFile()
        {
            this.UID = Guid.NewGuid();
            this.AF_Type = ImageType.StarAvatar;
        }

        public AvatarFile(string fullname) : this()
        {
            this.AF_Path = Path.GetDirectoryName(fullname);
            this.AF_Name = Path.GetFileName(fullname);
            this.AF_ImageType = Path.GetExtension(fullname);
        }
    }
}

