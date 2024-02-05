using BookApp.Business.Abstract;
using BookApp.Entities;
using BookApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index(string search = null)
        {
            var list = _bookService.GetList(search);
            List<BookModel> bookList = new List<BookModel>();
            foreach (var book in list)
            {
                BookModel bookModel = ConvertEntityToModel(book);
                bookList.Add(bookModel);
            }
            BookPageListModel model = new BookPageListModel()
            {
                BookList = bookList,
                Search = search
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);
            BookModel model = ConvertEntityToModel(book);
            return View(model);
        }

        [HttpPost]
        public JsonResult Create(BookModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(-1);
            }

            var book = ConvertModelToEntity(model);
            int count = _bookService.Create(book);
            return Json(count);
        }

        [HttpPost]
        public JsonResult Update(BookModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(-1);
            }

            var book = ConvertModelToEntity(model);
            int count = _bookService.Update(book);
            return Json(count);
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            int count = _bookService.Delete(id);
            return Json(count);
        }

        [HttpGet]
        public JsonResult DeleteHard(int id)
        {
            int count = _bookService.DeleteHard(id);
            return Json(count);
        }

        private BookModel ConvertEntityToModel(Book book)
        {
            BookModel bookModel = new BookModel()
            {
                BookName = book.BookName,
                Author = book.Author,
                ReleaseDate = book.ReleaseDate,
                Id = book.Id
            };

            return bookModel;
        }
        private Book ConvertModelToEntity(BookModel model)
        {
            Book book = new Book()
            {
                BookName = model.BookName,
                Author = model.Author,
                ReleaseDate = model.ReleaseDate,
                Id = model.Id
            };

            return book;
        }
    }
}
