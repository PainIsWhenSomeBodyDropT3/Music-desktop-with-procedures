using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.other
{
    class FindMessageConclusionByUsersIds : ICommand
    {
        private IMessageConclusionTimeService messageConclusionTimeService = ServiceFactory.getInstance().GetMessageConclusionTimeService();
        public object Execute(object request)
        {
            int[] arrData = (int[])request;
            int firstUserId = arrData[0];
            int secondUserId = arrData[1];
            return messageConclusionTimeService.findByUsersIds(firstUserId, secondUserId);
        }
    }
}
