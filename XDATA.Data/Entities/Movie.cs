using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace XDATA.Data
{
    class Movie : EntityBase
    {
        //public Guid M_UID { get; set; }
        public string M_ReleaseID { get; set; }
        public string M_ReleaseTitle { get; set; }
        public DateTime M_ReleaseDate { get; set; }
        public string M_Director { get; set; }
        public string M_Studio { get; set; }
        public long? M_Length { get; set; }
        public string M_Label { get; set; }
        public string M_Genre { get; set; }
        public string M_Censored { get; set; }
        public string M_StoreLocation { get; set; }
        //public ICollection<Guid> M_SampleFile_UIDs { get; set; }
        public virtual ICollection<SampleFile> M_SampleFiles { get; set; }
        public virtual ICollection<Star> M_Stars { get; set; }

        public Movie()
        {
            this.UID = Guid.NewGuid();
        }

        public Movie(string releaseid) : this()
        {
            this.M_ReleaseID = releaseid.Trim();
        }
    }
}
