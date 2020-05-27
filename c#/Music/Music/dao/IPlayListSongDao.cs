using Music.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.dao
{
    interface IPlayListSongDao:Dao<PlayListSong>
    {
        List<Song> getAllSongsByPlayListId(int id);

        PlayListSong readBySongAndPlayListIds(int songId, int playListId);
    }
}
