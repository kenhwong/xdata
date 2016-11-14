using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace XDATA.Data
{
    public class SampleFile : EntityBase, INotifyPropertyChanged
    {
        public Guid SF_M_UID { get; set; }
        public virtual Movie SF_Movie { get; set; }
        public string SF_Name { get; set; }
        public string SF_StoredPath { get; set; }
        public string SF_MIME { get; set; }
        public int SF_Width { get; set; }
        public int SF_Height { get; set; }
        public int SF_Length { get; set; }

        public SampleFile()
        {
            this.UID = Guid.NewGuid();
        }

        public SampleFile(string fullname) : this()
        {
            this.SF_StoredPath = Path.GetDirectoryName(fullname);
            this.SF_Name = Path.GetFileName(fullname);
            this.SF_MIME = Path.GetExtension(fullname);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
