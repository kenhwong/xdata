using System;
using System.Collections.Generic;

namespace XDATA
{
    public static class IOHelper
    {
        public static void CreateDirectoryIfNotExists(string directory)
        {
            lock (string.Intern(directory))
            {
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
        }

        public static string FormatMachineSize(long msize)
        {
            if (msize < 0)
            {
                throw new ArgumentOutOfRangeException("machine size");
            }
            else if (msize >= 1024 * 1024 * 1024) //大小大于或等于1024M
            {
                return string.Format("{0:0.00} G", (double)msize / (1024 * 1024 * 1024));
            }
            else if (msize >= 1024 * 1024) //大小大于或等于1024K
            {
                return string.Format("{0:0.00} M", (double)msize / (1024 * 1024));
            }
            else if (msize >= 1024) //大小大于等于1024
            {
                return string.Format("{0:0.00} K", (double)msize / 1024);
            }
            else
            {
                return string.Format("{0:0.00}", msize);
            }
        }

    }


}
