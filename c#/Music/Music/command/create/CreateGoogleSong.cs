using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Music.command.create
{
    class CreateGoogleSong : ICommand
    {
        private IGoogleSongService googleSongService = ServiceFactory.getInstance().GetGoogleSongService();
        public object Execute(object request)
        {
            object[] arrData = (object[])request;
            string filePath = (string)arrData[0];
            Song song = (Song)arrData[1];
            googleSongService.setFilePath(filePath);
            googleSongService.create(song);
            return null;
        }
    }
}
