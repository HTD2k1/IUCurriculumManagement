using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStorageService
{
    public interface IBlobStorageService
    {
        public Task UploadFiles(IFormFile file);
        public Task DownloadFiles(IFormFile file);
    }
}
