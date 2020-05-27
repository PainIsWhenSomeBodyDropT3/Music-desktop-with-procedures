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
    class SqlUserDao : IUserDao
    {
        public void create(User t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Users.Add(t);
                context.SaveChanges();
            }
        }

        public void delete(User t)
        {
            using (TestDbContext context = new TestDbContext())
            {
                context.Users.Attach(t);
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<User> getAllRegisterUser()
        {
            List<User> users = new List<User>();
            using (TestDbContext context = new TestDbContext())
            {
                foreach (User u in context.Users)
                {
                    if (u.Role == (int)Role.REGISTERED)
                    {
                        users.Add(u);
                    }
                }
            }
            return users;
        }

        public List<User> getAllUser()
        {
            throw new NotImplementedException();
        }

        public bool isExist(User user)
        {
           
            using (TestDbContext context = new TestDbContext())
            {
                foreach (User u in context.Users)
                {
                    if (u.Login.Trim().Equals(user.Login.Trim()) && u.Password.Trim().Equals(user.Password.Trim()))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool isRegistered(User user)
        {
            using (TestDbContext context = new TestDbContext())
            {
              foreach(User u in context.Users)
                {
                    if (u.Login.Trim().Equals(user.Login.Trim()))
                    {
                        return true;
                    }
                }
               
            }
            return false;
        }

        public User readById(int id)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (User u in context.Users)
                {
                    if (u.Id == id)
                    {
                        return u;
                    }
                }
            }
            return null;
        }

        public User readByName(string name)
        {
            using (TestDbContext context = new TestDbContext())
            {
                foreach (User u in context.Users)
                {
                    if (u.Login.Trim().Equals(name.Trim()))
                    {
                        return u;
                    }
                }

            }
            return null;
           
        }

        public User update(int id, User t)
        {
            User user = readById(id);
            using (TestDbContext context = new TestDbContext())
            {
                user.Login = t.Login;
                user.Password = t.Password;
                user.Role = t.Role;
                context.Users.Add(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

            }
            return user;
        }
    }
}
