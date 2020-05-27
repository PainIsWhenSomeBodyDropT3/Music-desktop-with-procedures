using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.read
{
    class ReadPlayListSongBySongAndPlayListIds : ICommand
    {
        private IPlayListSongService playListSongService = ServiceFactory.getInstance().GetPlayListSongService();
        public object Execute(object request)
        {
            object[] arrData = (object[])request;
            int songId = (int)arrData[0];
            int playListId = (int)arrData[1];
            return playListSongService.readBySongAndPlayListIds(songId, playListId);
        }
    }
}
