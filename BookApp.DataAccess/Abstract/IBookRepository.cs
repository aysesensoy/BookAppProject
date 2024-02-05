using BookApp.Entities;
using System.Collections.Generic;

namespace BookApp.DataAccess.Abstract
{
    public interface IBookRepository
    {
        Book Get(int id);

        List<Book> GetList(string filter = null);

        int Create(Book entity);

        int Update(Book entity);

        int DeleteHard(int id);

        int Delete(int id);

    }
}
