using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBook.Models
{
    public class TitleViewModel
    {
        public int? TitleId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FullName => "Title" + Title + " " + "Artist" + Artist;
    }
}