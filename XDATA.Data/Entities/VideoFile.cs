using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaInfoDotNet;

namespace XDATA.Data
{
    public class VideoFile : EntityBase
    {
        private MediaFile mf = null;

        public Guid MF_M_UID { get; set; }
        public string MF_FileFullName { get; set; }
        public string MF_FilePath { get; set; }
        public string MF_FileName { get; set; }
        public bool? MF_HasStreams { get; set; }
        public string MF_Summary { get; set; }
        public long? MF_FileSize { get; set; } 
        public TimeSpan? MF_Duration { get; set; }

        private VideoFile()
        {
            UID = Guid.NewGuid();
        }

        public VideoFile(string fullpath) : this()
        {
            MF_FileFullName = fullpath;
            MF_FilePath = Path.GetDirectoryName(fullpath);
            MF_FileName = Path.GetFileName(fullpath);
        }

        public void LoadInfo()
        {
            mf = new MediaFile(MF_FileFullName);
            MF_HasStreams = mf.HasStreams;
            MF_Summary = mf.Inform;

            MF_FileSize = mf.General.Size;
            MF_Duration = TimeSpan.FromMilliseconds(Convert.ToDouble(mf.General.Duration));
            if (mf.Video.Count > 0)
            {
                Type2D3D = Media2D3DType.Type2D;
                int nref = 1;

                VFormat = mf.format;
                VWidth = mf.Video[0].width;
                VHeight = mf.Video[0].height;
                VLength = tss;
                NRefFrame = 1;

                if (mf.Video[0].encoderSettings.Count > 0)
                {
                    if (int.TryParse(mf.Video[0].encoderSettings["ref"], out nref))
                        if (nref > 1)
                        {
                            Type2D3D = Media2D3DType.Type3D;
                            NRefFrame = nref;
                        }
                }
                MediaDecodeDesc = string.Format("[{0}, {1}*{2}, {3:00}:{4:00}:{5:00}, {6}, {7}]",
                    mf.format,
                    mf.Video[0].width,
                    mf.Video[0].height,
                    tss.Hours,
                    tss.Minutes,
                    tss.Seconds,
                    XGlobal.Format_MachineSize(mf.size),
                    Type2D3D);
            }
        }
    }
}
