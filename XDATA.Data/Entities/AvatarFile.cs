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
        public virtual Star AF_Star { get; set; }
        public string AF_Name { get; set; }
        public string AF_StoredPath { get; set; }
        public string AF_URL { get; set; }
        public string AF_MIME { get; set; }
        public int AF_Width { get; set; }
        public int AF_Height { get; set; }
        public int AF_Length { get; set; }

        public AvatarFile()
        {
            this.UID = Guid.NewGuid();
        }

        public AvatarFile(string fullname) : this()
        {
            this.AF_StoredPath = Path.GetDirectoryName(fullname);
            this.AF_Name = Path.GetFileName(fullname);
            this.AF_MIME = Path.GetExtension(fullname);
        }
    }
}

