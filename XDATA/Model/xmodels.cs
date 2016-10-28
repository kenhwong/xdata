using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;

namespace XDATA.Model
{
    public class Movie
    {
        public Guid M_UID { get; set; }
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
    }
    
    public class Star
    {
        public Guid S_UID { get; set; }
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
    }
    /*
    public class Perform
    {
        public Guid P_UID { get; set; }
        public Guid P_S_UID { get; set; }
        public virtual Star P_Star { get; set; }
        public Guid P_M_UID { get; set; }
        public virtual Movie P_Movie { get; set; }
    }
    */
    public class AvatarFile
    {
        //public Guid AF_UID { get; set; }
        public Guid AF_S_UID { get; set; }
        public virtual Star AF_Star { get; set; }
        public string AF_Name { get; set; }
        public string AF_Path { get; set; }
        //public ImageFormat AF_ImageType { get; set; }
        public string AF_ImageType { get; set; }
    }
    public class SampleFile
    {
        public Guid SF_UID { get; set; }
        public Guid SF_M_UID { get; set; }
        public virtual Movie SF_Movie { get; set; }
        public string SF_Name { get; set; }
        public string SF_Path { get; set; }
        //public ImageFormat SF_ImageType { get; set; }
        public string SF_ImageType { get; set; }
    }



}
