using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.dto;

namespace Music.dao.impl
{
    class SqlCommentDao : ICommentDao
    {
        public void create(Comment t)
        {
            using (TestDbContext context =new TestDbContext())
            {
                context.Comments.Add(t);
                context.SaveChanges();
            }
        }

        public void delete(Comment t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Comments.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Comment> getAllBySongId(int songId)
        {
            List<Comment> comments = new List<Comment>();
            using (TestDbContext context = new TestDbContext())
            {
                foreach (Comment c in context.Comments)
                {
                    if (c.SongId == songId)
                    {
                        comments.Add(c);
                    }
                }
            }
            return comments;
        }

            public List<Comment> getAllByUserId(int userId)
        {
            List<Comment> comments = new List<Comment>();
            using (TestDbContext context = new TestDbContext())
            {
                foreach (Comment c in context.Comments)
                {
                    if (c.UserId == userId)
                    {
                        comments.Add(c);
                    }
                }
            }
            return comments;
        }

        public Comment readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (Comment c in context.Comments)
                {
                    if (c.Id == id)
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public Comment update(int id, Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
