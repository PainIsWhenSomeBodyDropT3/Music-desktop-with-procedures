using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.service
{
    interface IGoogleSongService:Service<Song>
    {
        void setFilePath(string filePath);

        string getFullDownloadFilePath();
    }
}
