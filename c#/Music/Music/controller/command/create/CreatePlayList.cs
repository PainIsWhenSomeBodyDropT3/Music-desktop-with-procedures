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
    class CreatePlayList : ICommand
    {
        private IPlayListService playListService = ServiceFactory.getInstance().GetPlayListService();
        public object Execute(object request)
        {
            playListService.create((PlayList)request);
            return null;
        }
    }
}
