using BookApp.DataAccess.Abstract;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookApp.DataAccess.Concrete
{
    public class BookRepository : IBookRepository
    {
    
        public Book Get(int id)
        {
            using var dbContext = new BookAppDbContext();
            return dbContext.Books.Find(id);
        }
        public List<Book> GetList(string filter = null)
        {
            using var dbContext = new BookAppDbContext();
            if (string.IsNullOrEmpty(filter))
            {
                return dbContext.Books.Where(x => !x.IsDeleted).ToList();
            }
            return dbContext.Books.Where(x => !x.IsDeleted && x.BookName.ToLower().Contains(filter.ToLower())).ToList();
        }

        public int Create(Book entity)
        {
            using var dbContext = new BookAppDbContext();
            dbContext.Books.Add(entity);
            return dbContext.SaveChanges();
        }

        public int Update(Book entity)
        {
            using var dbContext = new BookAppDbContext();
            entity.UpdatedDate = DateTime.Now;
            dbContext.Books.Update(entity);
            return dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            using var dbContext = new BookAppDbContext();
            var entity = dbContext.Books.Find(id);
            entity.IsDeleted = true;
            dbContext.Books.Update(entity);
            return dbContext.SaveChanges();
        }
        public int DeleteHard(int id)
        {
            using var dbContext = new BookAppDbContext();
            var entity = dbContext.Books.Find(id);
            dbContext.Books.Remove(entity);
            return dbContext.SaveChanges();
        }
     
    }
}
