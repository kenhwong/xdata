using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDATA.Data
{
    class Star : EntityBase
    {
        //public Guid S_UID { get; set; }
        public string S_JName { get; set; }
        public string S_CName { get; set; }
        public string S_EName { get; set; }
        public DateTime? S_Birthday { get; set; }
        public int? S_Height { get; set; }
        public string S_Cup { get; set; }
        public int? S_BWH_B { get; set; }
        public int? S_BWH_W { get; set; }
        public int? S_BWH_H { get; set; }
        public string S_Hometown { get; set; }
        //public Guid? S_AvatarFile_UID { get; set; }
        public virtual AvatarFile S_AvatarFiles { get; set; }
        public virtual ICollection<Movie> S_Movies { get; set; }

        public Star()
        {
            this.UID = Guid.NewGuid();
        }

        public Star(string jname) : this()
        {
            this.S_JName = jname.Trim();
        }
    }
}
