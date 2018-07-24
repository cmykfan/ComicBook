using ComicBook.Models;
using System.Data.Entity.Migrations;

namespace ComicBook.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ComicBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // This is the good database that will work with migrations.
        protected override void Seed(ComicBookContext context)
        {
            context.Titles.AddOrUpdate(
                p => p.TitleId,
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
            );
        }
    }
}
