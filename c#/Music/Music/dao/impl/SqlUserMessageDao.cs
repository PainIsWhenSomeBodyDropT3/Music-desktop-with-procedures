using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.dto;

namespace Music.dao.impl
{
    class SqlUserMessageDao : IUserMessageDao
    {
        public void create(UserMessage t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.UserMessages.Add(t);
                context.SaveChanges();
            }
        }

        public void delete(UserMessage t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.UserMessages.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<UserMessage> getAllMessageByUserId(int id)
        {
            List<UserMessage> userMessages = new List<UserMessage>();
            IMessageDao messageDao = new SqlMessageDao();
            using (TestDbContext context = new TestDbContext())
            {
               
                foreach(UserMessage um in context.UserMessages)
                {
                    if(um.UserGetterId==id || messageDao.readById(um.MessageId).UserSenderId == id)
                    {
                        userMessages.Add(um);
                    }
                }
            }
            return userMessages;
        }

        public UserMessage readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (UserMessage u in context.UserMessages)
                {
                    if (u.Id == id)
                    {
                        return u;
                    }
                }
            }
            return null;
        }

        public UserMessage update(int id, UserMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
