using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBook.Models
{
    public class TitleListViewModel
    {
        public List<TitleViewModel> Titles { get; set; }
        public int TotalTitles { get; set; }
    }
}