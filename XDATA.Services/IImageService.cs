﻿using System;
using System.Web;
using XDATA.Data;

namespace XDATA.Services
{
    public interface IImageService
    {
        string GetOriginalPath(Guid id);
        string SaveAndReturnKey(ImageType type, HttpPostedFileBase file, Guid userId, bool cropCenter);
        string SaveAndReturnKey(ImageType type, Base64Image base64Image, Guid userId, bool cropCenter);
        string DownloadAndReturnKey(ImageType type, string url, Guid userId, bool cropCenter);
    }
}
