using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.delete
{
    class DeletePlayListSong : ICommand
    {
        private IPlayListSongService playListSongService = ServiceFactory.getInstance().GetPlayListSongService();

        public object Execute(object request)
        {
            playListSongService.delete((PlayListSong)request);
            return null;
        }
    }
}
