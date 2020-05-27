using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.read
{
    class ReadGoogleSongById : ICommand
    {
        private IGoogleSongService googleSongService = ServiceFactory.getInstance().GetGoogleSongService();
        public object Execute(object request)
        {
            return googleSongService.readById((int)request);
        }
    }
}
