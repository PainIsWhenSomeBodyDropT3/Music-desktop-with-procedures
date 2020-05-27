using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.update
{
    class UpdateSong : ICommand
    {
        private ISongService songService = ServiceFactory.getInstance().GetSongService();
        public object Execute(object request)
        {
            object[] arrData = (object[])request;
            int id = (int)arrData[0];
            Song song = (Song)arrData[1];
           
            return songService.update(id,song);
        }
    }
}
