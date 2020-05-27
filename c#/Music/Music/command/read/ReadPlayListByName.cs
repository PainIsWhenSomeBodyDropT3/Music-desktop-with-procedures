using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.read
{
    class ReadPlayListByName : ICommand
    {
        private IPlayListService playListService = ServiceFactory.getInstance().GetPlayListService();
        public object Execute(object request)
        {
            return playListService.readNyName((string)request);
        }
    }
}
