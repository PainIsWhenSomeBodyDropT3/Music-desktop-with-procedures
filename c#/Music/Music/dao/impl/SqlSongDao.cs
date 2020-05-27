using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.dto;

namespace Music.dao.impl
{
    class SqlSongDao : ISongDao
    {
        public void create(Song t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Songs.Add(t);
                context.SaveChanges();
            }
        }

        public void delete(Song t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Songs.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Song> getAllSong()
        {
            List<Song> songs = new List<Song>();
            using (TestDbContext context = new TestDbContext())
            {
                foreach(Song s  in context.Songs)
                {
                    songs.Add(s);
                }
            }
            return songs;
        }

        public Song readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (Song s in context.Songs)
                {
                    if (s.Id == id)
                    {
                        return s;
                    }
                }
            }
            return null;
        }



        public Song update(int id, Song t)
        {
            Song song = readById(id);
            using (TestDbContext context = new TestDbContext())
            {
                song.LocalUrl = t.LocalUrl;
                song.Name = t.Name;
                song.NumberOfPlays = t.NumberOfPlays;
                song.ReleaseDate = t.ReleaseDate;
                song.Type = t.Type;
                song.Duraction = song.Duraction;
                song.Description = t.Description;
                song.AuthorName = t.AuthorName;
                song.Album = t.Album;

                context.Songs.Add(song);
                context.Entry(song).State = EntityState.Modified;
                context.SaveChanges();
            }
            return song;
        }
    }
}
