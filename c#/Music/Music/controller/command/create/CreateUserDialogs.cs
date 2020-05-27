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
    class CreateUserDialogs : ICommand
    {
        private IDialogService dialogService = ServiceFactory.getInstance().GetDialogService();
        private IUserMessageService userMessageService = ServiceFactory.getInstance().GetUserMessageService();
        public object Execute(object request)
        {
            List<UserMessage> userMessages = userMessageService.getAllMessageByUserId((int)request);
            return dialogService.createDialogs(userMessages, (int)request);
        }
    }
}
