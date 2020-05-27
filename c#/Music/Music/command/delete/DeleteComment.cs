using Music.controller;
using Music.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.command.delete
{
    class DeleteComment : ICommand
    {
        private ICommentService commentService = ServiceFactory.getInstance().GetCommentService();

        public object Execute(object request)
        {
            commentService.delete((Comment)request);
            return null;
        }
    }
}
