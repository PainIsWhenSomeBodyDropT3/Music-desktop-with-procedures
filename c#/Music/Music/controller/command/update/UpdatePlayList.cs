using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.update
{
    class UpdatePlayList : ICommand
    {
        private IPlayListService playListService = ServiceFactory.getInstance().GetPlayListService();
        public object Execute(object request)
        {
            object[] arrData = (object[])request;
            int id = (int)arrData[0];
            PlayList playList = (PlayList)arrData[1];

            return playListService.update(id, playList);
        }
    }
}
