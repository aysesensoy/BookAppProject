using BookApp.Business.Abstract;
using BookApp.DataAccess.Abstract;
using BookApp.Entities;
using System.Collections.Generic;

namespace BookApp.Business.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }
        public Book Get(int id)
        {
            var book = _repository.Get(id);
            return book;
        }
        public List<Book> GetList(string filter = null)
        {
            var list = _repository.GetList(filter);
            return list;
        }

        public int Create(Book entity)
        {
            var count = _repository.Create(entity);
            return count;
        }

        public int Update(Book entity)
        {
            var count = _repository.Update(entity);
            return count;
        }
        public int Delete(int id)
        {
            var count = _repository.Delete(id);
            return count;
        }
        public int DeleteHard(int id)
        {
            var count = _repository.DeleteHard(id);
            return count;
        }
    }
}
