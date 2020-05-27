using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.dto;

namespace Music.dao.impl
{
    class SqlPlayListDao : IPlayListDao
    {
        public void create(PlayList t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.PlayLists.Add(t);
                context.SaveChanges();
            }
        }

        public void delete(PlayList t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.PlayLists.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<PlayList> getAllByUserId(int userId)
        {
            List<PlayList> lists = new List<PlayList>();
            using (TestDbContext context = new TestDbContext())
            {
                foreach (PlayList p in context.PlayLists)
                {
                    if (p.UserId == userId)
                    {
                        lists.Add(p);
                    }
                }
            }
            return lists;
        }

        public PlayList readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (PlayList p in context.PlayLists)
                {
                    if (p.Id == id)
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        public PlayList readByName(string name)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (PlayList p in context.PlayLists)
                {
                    if (p.Name.Trim() == name.Trim())
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        public PlayList update(int id, PlayList t)
        {
            PlayList playList = readById(id);
            using (TestDbContext context = new TestDbContext())
            {
                playList.Name = t.Name;
                playList.Description = t.Description;
                playList.UserId = t.UserId;


                context.PlayLists.Add(playList);
                context.Entry(playList).State = EntityState.Modified;
                context.SaveChanges();
            }
            return playList;
        }
    }
}
