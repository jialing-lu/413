using System;
using System.Linq;

namespace _413.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Books> Books { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
