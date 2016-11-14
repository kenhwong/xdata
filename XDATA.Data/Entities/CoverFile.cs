using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace XDATA.Data
{
    public class CoverFile : EntityBase, INotifyPropertyChanged
    {
        public virtual Movie CF_Movie { get; set; }
        public string CF_Name { get; set; }
        public string CF_StoredPath { get; set; }
        public string CF_URL { get; set; }
        public string CF_MIME { get; set; }
        public int CF_Width { get; set; }
        public int CF_Height { get; set; }
        public int CF_Length { get; set; }

        public CoverFile()
        {
            this.UID = Guid.NewGuid();
        }

        public CoverFile(string fullname) : this()
        {
            this.CF_StoredPath = Path.GetDirectoryName(fullname);
            this.CF_Name = Path.GetFileName(fullname);
            this.CF_MIME = Path.GetExtension(fullname);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

