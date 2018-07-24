using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBook.Models
{
    // Creating the Title Name and Artist.
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
    }
}