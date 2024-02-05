using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Models
{
    public class BookPageListModel
    {
        public List<BookModel> BookList { get; set; }
        public string Search { get; set; }
    }
}
