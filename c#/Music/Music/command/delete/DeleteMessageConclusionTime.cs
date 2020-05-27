using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command
{
    class DeleteMessageConclusionTime : ICommand
    {
        private IMessageConclusionTimeService messageConclusionTimeService = ServiceFactory.getInstance().GetMessageConclusionTimeService();
        public object Execute(object request)
        {
            messageConclusionTimeService.delete((MessageConclusionTime)request);
            return null;
        }
    }
}
