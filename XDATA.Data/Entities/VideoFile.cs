using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaInfoDotNet;
using XDATA;
using System.ComponentModel;

namespace XDATA.Data
{
    public class VideoFile : EntityBase, INotifyPropertyChanged
    {
        private MediaFile mf = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public Guid VF_M_UID { get; set; }
        public virtual Movie VF_Movie { get; set; }
        public string VF_FileFullName { get; set; }
        public string VF_FilePath { get; set; }
        public string VF_FileName { get; set; }
        public bool? VF_HasStreams { get; set; } = false;
        public string VF_Summary { get; set; }
        public string VF_Desc { get; set; }
        public long VF_FileSize { get; set; } = 0;
        public TimeSpan VF_Duration { get; set; } = TimeSpan.Zero;
        public string VF_2D3D { get; set; } = "2D";
        public string VF_VideoFormat { get; set; }
        public string VF_VideoMIME { get; set; }
        public int VF_VideoWidth { get; set; } = 0;
        public int VF_VideoHeight { get; set; } = 0;
        public int VF_VideoNRefFrame { get; set; } = 0;

        private VideoFile()
        {
            UID = Guid.NewGuid();
        }

        public VideoFile(string fullpath) : this()
        {
            VF_FileFullName = fullpath;
            VF_FilePath = Path.GetDirectoryName(fullpath);
            VF_FileName = Path.GetFileName(fullpath);

            mf = new MediaFile(VF_FileFullName);
            VF_HasStreams = mf.HasStreams;
            VF_Summary = mf.Inform;

            VF_FileSize = mf.General.Size;
            VF_Duration = TimeSpan.FromMilliseconds(Convert.ToDouble(mf.General.Duration));
            if (mf.Video.Count > 0)
            {
                int nref = 1;
                VF_VideoFormat = mf.General.Format;
                VF_VideoMIME = mf.General.InternetMediaType;
                VF_VideoWidth = mf.Video[0].width;
                VF_VideoHeight = mf.Video[0].height;
                VF_VideoNRefFrame = 1;

                if (mf.Video[0].EncoderSettings.Count > 0)
                {
                    if (int.TryParse(mf.Video[0].encoderSettings["ref"], out nref))
                        if (nref > 1)
                        {
                            VF_2D3D = "3D";
                            VF_VideoNRefFrame = nref;
                        }
                }
            }
            VF_Desc = $"{VF_VideoFormat}, {VF_VideoWidth}*{VF_VideoHeight}, {VF_Duration.Hours:00}:{VF_Duration.Minutes:00}:{VF_Duration.Seconds:00}, {IOHelper.FormatMachineSize(VF_FileSize)}, {VF_2D3D}";

        }
    }
}
