using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command
{
    class ReadMessageById : ICommand
    {
        private IMessageService messageService = ServiceFactory.getInstance().GetMessageService();
        public object Execute(object request)
        {
            return messageService.readById((int)request);
        }
    }
}
