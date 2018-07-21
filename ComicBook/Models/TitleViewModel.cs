using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ComicBook.Models
{
    public class TitleViewModel
    {
        public int? TitleId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Artist")]
        public string Artist { get; set; }

        [DisplayName("Title")]
        public string FullName => "Title " + Name + " " + "Artist " + Artist;
    }
}