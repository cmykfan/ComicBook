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
        //public static List<Title> Titles = new List<Title>  Remove this now that we are adding to Database - Migrations.
        //{
        //new Title { TitleId = 1, Name = "Hellboy", Artist = "Mike Mignola" },
        //new Title { TitleId = 2, Name = "The Incredible Hulk", Artist = "Jack Kirby" },
        //new Title { TitleId = 3, Name = "Spider-Man", Artist = "Steve Ditko" },
        //new Title { TitleId = 4, Name = "X-Men", Artist = "John Byrne" },
        //new Title { TitleId = 5, Name = "Airtight Garage", Artist = "Moebius" },
        //new Title { TitleId = 6, Name = "Dr. Strange", Artist = "Steve Ditko" },
        //new Title { TitleId = 7, Name = "Silver Surfer", Artist = "Ron Lim" },
        //new Title { TitleId = 8, Name = "Warlock", Artist = "Jim Starlin" },
        //new Title { TitleId = 9, Name = "Swamp Thing", Artist = "Steve Bissette" },
        //new Title { TitleId = 10, Name = "Nexus", Artist = "Steve Rude" },
        //new Title { TitleId = 11, Name = "Captain America", Artist = "Jack Kirby" },
        //new Title { TitleId = 12, Name = "Sandman", Artist = "P. Craig Russell" },
        //new Title { TitleId = 13, Name = "Concrete", Artist = "Paul Chadwick" },
        //new Title { TitleId = 14, Name = "The Spirit", Artist = "Will Eisner" },
        //new Title { TitleId = 15, Name = "Daredevil", Artist = "Frank Miller" }
        //};

        public ActionResult Index()
        {
            using (var comicbookContext = new ComicBookContext())
            {
                var titleList = new TitleListViewModel 
                {
                    Titles = comicbookContext.Titles.Select(p => new TitleViewModel
                    {
                        TitleId = p.TitleId,
                        Name = p.Name,
                        Artist = p.Artist
                    }).ToList()
                };

                titleList.TotalTitles = titleList.Titles.Count;

                return View(titleList);
            }
            
        }

        public ActionResult TitleDetail(int id)
        {
            using (var comicbookContext = new ComicBookContext())
            {
                var title = comicbookContext.Titles.SingleOrDefault(p => p.TitleId == id);

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

            }

            return new HttpNotFoundResult();
        }

        // The AddEditTitle link.
        public ActionResult TitleAdd()
        {
            var titleViewModel = new TitleViewModel();

            return View("AddEditTitle", titleViewModel);
        }

        //Add title result
        [HttpPost]
        public ActionResult AddTitle(TitleViewModel titleViewModel)
        {
            using (var comicbookContext = new ComicBookContext())
            {
                var title = new Title
                {
                    //TitleId = nextTitleId,  Don't need.
                    Name = titleViewModel.Name,
                    Artist = titleViewModel.Artist
                };

                comicbookContext.Titles.Add(title);
                comicbookContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Action result for Editing the title.
        public ActionResult TitleEdit(int id)
        {
            using (var comicbookContext = new ComicBookContext())
            {
                var title = comicbookContext.Titles.SingleOrDefault(p => p.TitleId == id);
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
            }

            return new HttpNotFoundResult();
        }

        // Edit Title result.
        [HttpPost]
        public ActionResult EditTitle(TitleViewModel titleViewModel)
        {
            using (var comicbookContext = new ComicBookContext())
            {
                var title = comicbookContext.Titles.SingleOrDefault(p => p.TitleId == titleViewModel.TitleId);

                if (title != null)
                {
                    title.Name = titleViewModel.Name;
                    title.Artist = titleViewModel.Artist;
                    comicbookContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        // Delete Title result.
        [HttpPost]
        public ActionResult DeleteTitle(TitleViewModel titleViewModel)
        {
            using (var comicbookContext = new ComicBookContext())
            {
                var title = comicbookContext.Titles.SingleOrDefault(p => p.TitleId == titleViewModel.TitleId);

                if (title != null)
                {
                    comicbookContext.Titles.Remove(title);
                    comicbookContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}