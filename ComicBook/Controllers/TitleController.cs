using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicBook.Models;

namespace ComicBook.Controllers
{
    public class TitleController : Controller
    {
        // GET: Title
        public static List<Title> Titles = new List<Title>
        {
            new Title { TitleId = 1, Name = "Hellboy", Artist = "Mike Mignola" },
            new Title { TitleId = 2, Name = "The Incredible Hulk", Artist = "Jack Kirby" },
            new Title { TitleId = 3, Name = "Spider-Man", Artist = "Steve Ditko" },
            new Title { TitleId = 4, Name = "X-Men", Artist = "John Byrne" },
            new Title { TitleId = 5, Name = "Airtight Garage", Artist = "Moebius" },
            new Title { TitleId = 6, Name = "Dr. Strange", Artist = "Steve Ditko" },
            new Title { TitleId = 7, Name = "Silver Surfer", Artist = "Ron Lim" },
            new Title { TitleId = 8, Name = "Warlock", Artist = "Jim Starlin" },
            new Title { TitleId = 9, Name = "Swamp Thing", Artist = "Steve Bissette" },
            new Title { TitleId = 10, Name = "Nexus", Artist = "Steve Rude" },
            new Title { TitleId = 11, Name = "Captain America", Artist = "Jack Kirby" },
            new Title { TitleId = 12, Name = "Sandman", Artist = "P. Craig Russell" },
            new Title { TitleId = 13, Name = "Concrete", Artist = "Paul Chadwick" },
            new Title { TitleId = 14, Name = "The Spirit", Artist = "Will Eisner" },
            new Title { TitleId = 15, Name = "Daredevil", Artist = "Frank Miller" }
        };

        public ActionResult Index()
        {
            var titleList = new TitleListViewModel
            {
                Titles = Titles.Select(p => new TitleViewModel
                {
                    TitleId = p.TitleId,
                    Name = p.Name,
                    Artist = p.Artist
                }).ToList()
            };

            titleList.TotalTitles = titleList.Titles.Count;

            return View(titleList);
        }

        public ActionResult TitleDetail(int id)
        {
            var title = Titles.SingleOrDefault(p => p.TitleId == id);

            if (title != null)
            {
                var titleViewModel = new TitleViewModel
                {
                    TitleId = title.TitleId,
                    Name = title.Name,
                    Artist = title.Artist
                };

                return View(titleViewModel);
            }

            return new HttpNotFoundResult();
        }

        public ActionResult TitleAdd()
        {
            var titleViewModel = new TitleViewModel();

            return View("AddEditTitle", titleViewModel);
        }

        public ActionResult TitleEdit(int id)
        {
            var title = Titles.SingleOrDefault(p => p.TitleId == id);

            if (title != null)
            {
                var titleViewModel = new TitleViewModel
                {
                    TitleId = title.TitleId,
                    Name = title.Name,
                    Artist = title.Artist
                };

                return View("AddEditTitle", titleViewModel);
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult AddTitle(TitleViewModel titleViewModel)
        {
            var nextTitleId = Titles.Max(p => p.TitleId) + 1;

            var title = new Title
            {
                TitleId = nextTitleId,
                Name = titleViewModel.Name,
                Artist = titleViewModel.Artist
            };

            Titles.Add(title);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditTitle(TitleViewModel titleViewModel)
        {
            var title = Titles.SingleOrDefault(p => p.TitleId == titleViewModel.TitleId);

            if (title != null)
            {
                title.Name = titleViewModel.Name;
                title.Artist = titleViewModel.Artist;

                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }

    }
}