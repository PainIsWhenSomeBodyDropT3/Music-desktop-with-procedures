using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.dao
{
    interface IGoogleSongDao : Dao<Song>
    {
        void setFilePath(string filePath);

        string getFullDownloadFilePath();
    }
}
