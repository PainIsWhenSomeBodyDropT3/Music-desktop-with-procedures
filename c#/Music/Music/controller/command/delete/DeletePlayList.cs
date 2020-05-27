using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.delete
{
    class DeletePlayList : ICommand
    {
        private IPlayListService playListService = ServiceFactory.getInstance().GetPlayListService();

        public object Execute(object request)
        {
            playListService.delete((PlayList)request);
            return null;
        }
    }
}
