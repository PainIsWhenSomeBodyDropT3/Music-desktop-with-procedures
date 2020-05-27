using Music.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.service.impl
{
    class GoogleSongService :IGoogleSongService
    {
        private IGoogleSongDao songGoogleDao = DaoFactory.getInstance().GetGooleSongDao();
        public void create(Song t)
        {
            songGoogleDao.create(t);
        }

        public void delete(Song t)
        {
            songGoogleDao.delete(t);
        }

        public string getFullDownloadFilePath()
        {
            return songGoogleDao.getFullDownloadFilePath();
        }

        public Song readById(int id)
        {
            return songGoogleDao.readById(id);
        }

        public void setFilePath(string filePath)
        {
            songGoogleDao.setFilePath(filePath);
        }

        public Song update(int id, Song t)
        {
            return songGoogleDao.update(id, t);
        }
    }
}
