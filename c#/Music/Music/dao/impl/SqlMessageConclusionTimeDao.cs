using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.dto;

namespace Music.dao.impl
{
    class SqlMessageConclusionTimeDao : IMessageConclusionTimeDao
    {
        public void create(MessageConclusionTime t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.MessageConclusionTimes.Add(t);
                context.SaveChanges();
            }
        }

        public void delete(MessageConclusionTime t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.MessageConclusionTimes.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public MessageConclusionTime findByUsersIds(int firstUserId, int secondUserId)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (MessageConclusionTime m in context.MessageConclusionTimes)
                {
                    if ((m.FirstUserId == firstUserId && m.SecondUserId == secondUserId)
                        || m.FirstUserId == secondUserId && m.SecondUserId == firstUserId)
                    {
                        return m;
                    }
                }
            }
            return null ;
        }

        public List<MessageConclusionTime> getAllByUserId(int userId)
        {
            List<MessageConclusionTime> messageConclusionTimes = new List<MessageConclusionTime>();
            using (TestDbContext context = new TestDbContext())
            {
                foreach (MessageConclusionTime m in context.MessageConclusionTimes)
                {
                    if (m.FirstUserId == userId || m.SecondUserId == userId)
                    {
                        messageConclusionTimes.Add(m);
                    }
                }
            }
            return messageConclusionTimes;
        }

        public MessageConclusionTime readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (MessageConclusionTime m in context.MessageConclusionTimes)
                {
                    if (m.Id == id)
                    {
                        return m;
                    }
                }
            }
            return null;
        }

        public MessageConclusionTime update(int id, MessageConclusionTime t)
        {
            MessageConclusionTime messageConclusionTime = readById(id);
            using (TestDbContext context = new TestDbContext())
            {
                messageConclusionTime.FirstUserId = t.FirstUserId;
                messageConclusionTime.SecondUserId = t.SecondUserId;
                messageConclusionTime.FirstUserDate = t.FirstUserDate;
                messageConclusionTime.SecondUserDate = t.SecondUserDate;

                context.MessageConclusionTimes.Add(messageConclusionTime);
                context.Entry(messageConclusionTime).State = EntityState.Modified;
                context.SaveChanges();
            }
            return messageConclusionTime;
        }
    }
}
