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
    class CreateUserMessage : ICommand
    {
        private IUserMessageService userMessageService = ServiceFactory.getInstance().GetUserMessageService();
        public object Execute(object request)
        {
            userMessageService.create((UserMessage)request);
            return null;
        }
    }
}
