using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command
{
    class ReadUserByName : ICommand
    {
        private IUserService userService = ServiceFactory.getInstance().GetUserService();

        public object Execute(object request)
        {
            return userService.readByName((string)request);
        }
    }
}
