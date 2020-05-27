using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.delete
{
    class DeleteSong : ICommand
    {
        private ISongService songService = ServiceFactory.getInstance().GetSongService();
        private IGoogleSongService googleSongService = ServiceFactory.getInstance().GetGoogleSongService();

        public object Execute(object request)
        {
            Song song = (Song)request;
            googleSongService.delete(song);
            songService.delete(song);
            return null;
        }
    }
}
