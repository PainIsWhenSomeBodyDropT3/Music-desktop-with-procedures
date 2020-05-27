using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.dto;

namespace Music.dao.impl
{
    class SqlPlayListSongDao : IPlayListSongDao
    {
        public void create(PlayListSong t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.PlayListSongs.Add(t);
                context.SaveChanges();
            }
        }

        public void delete(PlayListSong t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.PlayListSongs.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Song> getAllSongsByPlayListId(int id)
        {
            ISongDao songDao = new SqlSongDao();
            List<Song> songs = new List<Song>();
            using (TestDbContext context = new TestDbContext())
            {
                foreach(PlayListSong p in context.PlayListSongs)
                {
                    if (p.PlayListId == id)
                    {
                        songs.Add(songDao.readById(p.SongId));
                    }
                }
            }
            return songs;
        }

        public PlayListSong readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (PlayListSong p in context.PlayListSongs)
                {
                    if (p.Id == id)
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        public PlayListSong readBySongAndPlayListIds(int songId, int playListId)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (PlayListSong p in context.PlayListSongs)
                {
                    if (p.SongId == songId && p.PlayListId==playListId)
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        public PlayListSong update(int id, PlayListSong t)
        {
            throw new NotImplementedException();
        }
    }
}
