using System;
using System.Linq;
using ComicBook.Models;
using System.Data.Entity;

namespace ComicBook
{
    public class ComicBookContext : DbContext
    {
        public ComicBookContext() : base("name=ComicBook") { }
            
        public virtual DbSet<Title> Titles { get; set; }
            
    }
}


// Your context has been configured to use a 'ComicBookContext' connection string from your application's 
// configuration file (App.config or Web.config). By default, this connection string targets the 
// 'ComicBook.ComicBookContext' database on your LocalDb instance. 
// 
// If you wish to target a different database and/or database provider, modify the 'ComicBookContext' 
// connection string in the application configuration file.


// Add a DbSet for each entity type that you want to include in your model. For more information 
// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

// public virtual DbSet<MyEntity> MyEntities { get; set; }

//public class MyEntity
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
