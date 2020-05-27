using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.delete
{
    class DeleteUserDialog : ICommand
    {
        private IUserMessageService userMessageService = ServiceFactory.getInstance().GetUserMessageService();
        private IMessageService messageService = ServiceFactory.getInstance().GetMessageService();

        public object Execute(object request)
        {
            List<UserMessage> userMessages = userMessageService.getAllMessageByUserId((int)request);
            foreach (UserMessage u in userMessages)
            {
                Message message = messageService.readById(u.MessageId);
                userMessageService.delete(u);
                messageService.delete(message);
            }
            return null;
        }
    }
}
