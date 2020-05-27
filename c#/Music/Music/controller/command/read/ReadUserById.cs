using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.read
{
    class ReadUserById : ICommand
    {
        private IUserService userService = ServiceFactory.getInstance().GetUserService();

        public object Execute(object request)
        {
            return userService.readById((int)request);
        }
    }
}
