using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.delete
{
    class DeleteUserMessage : ICommand
    {
        private IUserMessageService userMessageService = ServiceFactory.getInstance().GetUserMessageService();

        public object Execute(object request)
        {
            userMessageService.delete((UserMessage)request);
            return null;
        }
    }
}
