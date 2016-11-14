using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using MediaInfoDotNet;
using System.ComponentModel;
using PropertyChanged;

namespace XDATA.Data
{
    public class Movie : EntityBase, INotifyPropertyChanged
    {
        public string M_ReleaseID { get; set; }
        public string M_ReleaseTitle { get; set; }
        public DateTime M_ReleaseDate { get; set; } = DateTime.MinValue;
        public string M_Director { get; set; }
        public string M_Studio { get; set; }
        public TimeSpan M_Duration { get; set; } = TimeSpan.Zero;
        public string M_Label { get; set; }
        public string M_Genre { get; set; }
        public string M_Censored { get; set; }
        public string M_PageURL { get; set; }
        public Guid M_CategorizedStarUID { get; set; }
        public long M_FileSize { get; set; }
        public string M_MIME { get; set; }
        public string M_SourcePath { get; set; }
        public string M_StoredPath { get; set; }
        public virtual ICollection<SampleFile> M_SampleFiles { get; set; }
        public virtual ICollection<Star> M_Stars { get; set; }
        public virtual ICollection<VideoFile> M_VideoFiles { get; set; }
        public virtual CoverFile M_CoverFile { get; set; }

        public Movie()
        {
            this.UID = Guid.NewGuid();
            if (M_VideoFiles?.Count > 0)
            {
                M_Duration = M_VideoFiles.Sum(vf => vf.VF_Duration);
                M_FileSize = M_VideoFiles.Sum(vf => vf.VF_FileSize);
                M_MIME = M_VideoFiles.First().VF_VideoMIME;
            }
        }

        public Movie(string releaseid) : this()
        {
            M_ReleaseID = releaseid.Trim();
        }

        public Movie(FileInfo sourceFI) : this()
        {
            M_SourcePath = sourceFI.DirectoryName;
            MediaFile f = new MediaFile(sourceFI.FullName);
            if(f.HasStreams)
            {
                GetVideoFilesFromSource(sourceFI.Extension);
                M_MIME = f.General.InternetMediaType;
                M_FileSize = M_VideoFiles.Sum<VideoFile>(vf => vf.VF_FileSize);
                M_Duration = M_VideoFiles.Sum<VideoFile>(vf => vf.VF_Duration);
            }
            f.General.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GetVideoFilesFromSource(string strext)
        {
            if (M_SourcePath == null) return;
            var vfs = Directory.EnumerateFiles(M_SourcePath, $"*.{strext}");
            foreach (string vf in vfs) M_VideoFiles.Add(new VideoFile(vf));
        }
    }
}
