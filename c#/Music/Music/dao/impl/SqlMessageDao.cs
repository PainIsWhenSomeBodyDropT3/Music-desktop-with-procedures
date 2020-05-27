using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Music.dto;

namespace Music.dao.impl
{
    class SqlMessageDao : IMessageDao
    {
        public void create(Message t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Messages.Add(t);
                context.SaveChanges();
            }
        }

        public Message createAndReturn(Message message)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Messages.Add(message);
                context.SaveChanges();

               List<Message> messages = context.Messages.ToList();
                return messages.Last();
            }
        }

        public void delete(Message t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Messages.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Message readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (Message m in context.Messages)
                {
                    if (m.Id == id)
                    {
                        return m;
                    }
                }
            }
            return null;
        }

        public Message update(int id, Message t)
        {
            throw new NotImplementedException();
        }
    }
}
