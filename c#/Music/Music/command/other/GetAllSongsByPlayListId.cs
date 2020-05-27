using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.other
{
    class GetAllSongsByPlayListId : ICommand
    {
        private IPlayListSongService playListSongService = ServiceFactory.getInstance().GetPlayListSongService();
        public object Execute(object request)
        {
            return playListSongService.getAllSongsByPlayListId((int)request);
        }
    }
}
