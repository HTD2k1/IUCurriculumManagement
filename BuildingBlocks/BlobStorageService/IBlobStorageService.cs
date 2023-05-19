﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageService
{
    public interface IBlobStorageService
    {
        public Task UploadFilesAsync(IFormFile file);
        public Task DownloadFilesAsync(string fileName);

    }
}
