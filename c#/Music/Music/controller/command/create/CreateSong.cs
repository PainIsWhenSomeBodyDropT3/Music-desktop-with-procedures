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
    class CreateSong : ICommand
    {
        private ISongService songService = ServiceFactory.getInstance().GetSongService();
        public object Execute(object request)
        {
            songService.create((Song)request);
            return null; 
        }
    }
}
