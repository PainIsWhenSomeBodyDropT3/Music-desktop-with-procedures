using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.create
{
    class CreateMessageConclusionTime : ICommand
    {
        private IMessageConclusionTimeService messageConclusionTimeService = ServiceFactory.getInstance().GetMessageConclusionTimeService();

        public object Execute(object request)
        {
            messageConclusionTimeService.create((MessageConclusionTime)request);
            return null;
        }
    }
}
