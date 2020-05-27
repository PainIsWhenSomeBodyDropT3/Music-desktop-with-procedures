using Music.dto;
using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command
{
    class CreatePlayListSong : ICommand
    {
        private IPlayListSongService playListSongService = ServiceFactory.getInstance().GetPlayListSongService();
        public object Execute(object request)
        {
            playListSongService.create((PlayListSong)request);
            return null;
        }
    }
}
