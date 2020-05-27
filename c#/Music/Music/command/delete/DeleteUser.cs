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
    class DeleteUser : ICommand
    {
        private IUserService userService = ServiceFactory.getInstance().GetUserService();
        private IPlayListService playListService = ServiceFactory.getInstance().GetPlayListService();
        private ICommentService commentService = ServiceFactory.getInstance().GetCommentService();
        private IUserMessageService userMessageService = ServiceFactory.getInstance().GetUserMessageService();
        private IMessageService messageService = ServiceFactory.getInstance().GetMessageService();
        private IMessageConclusionTimeService messageConclusionTimeService = ServiceFactory.getInstance().GetMessageConclusionTimeService();
        public object Execute(object request)
        {
            using (TestDbContext context = new TestDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        User user = (User)request;
                        List<PlayList> playLists = playListService.getAllByUserId(user.Id);
                        List<Comment> comments = commentService.getAllByUserId(user.Id);
                        List<UserMessage> userMessages = userMessageService.getAllMessageByUserId(user.Id);
                        List<MessageConclusionTime> messageConclusionTimes = messageConclusionTimeService.getAllByUserId(user.Id);
                        foreach (PlayList p in playLists)
                        {

                            playListService.delete(p);
                        }
                        foreach (Comment c in comments)
                        {
                            commentService.delete(c);
                        }
                        foreach (UserMessage u in userMessages)
                        {
                            Message message = messageService.readById(u.MessageId);
                            userMessageService.delete(u);
                            messageService.delete(message);
                        }
                        foreach (MessageConclusionTime m in messageConclusionTimes)
                        {
                            messageConclusionTimeService.delete(m);
                        }

                        userService.delete(user);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
            return null;
        }
    }
}
