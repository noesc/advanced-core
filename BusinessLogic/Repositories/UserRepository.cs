using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Repositories
{
    public class UserRepository
    {
        private AdvancedDBContext context;
        private bool disposedValue = false;

        public UserRepository(AdvancedDBContext context)
        {
            this.context = context;
        }

        public void Insert(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int UserId)
        {
            User user = context.User.Find(UserId);
            context.User.Remove(user);
            context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return context.User.ToList();
        }

        public User GetUserById(int UserId)
        {
            return context.User.Find(UserId);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
