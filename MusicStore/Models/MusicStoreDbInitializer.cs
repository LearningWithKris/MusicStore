using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MusicStore.Models
{
    //public class MusicStoreDbInitializer: DropCreateDatabaseAlways<MusicStoreDB>
    //public class MusicStoreDbInitializer: CreateDatabaseIfNotExists<MusicStoreDB> // DropCreateDatabaseAlways<MusicStoreDB>
    public class MusicStoreDbInitializer: CreateDatabaseIfNotExists<MusicStoreDB> // <MusicStoreDB>
    {
        protected override void Seed(MusicStoreDB context)
        {


            //context.Artists.Add(new Artist { Name = "Bon Jovi" });
            //context.Genres.Add(new Genre { Name = "80s Hair Band" });
            // NOTE: This was causing issues because it didn't have enough information when creating the record in the database.
            //       And was causing the error in the StoreManagerController.Index method.
            //context.Albums.Add(new Album  {Title = "New Jersey"});

            context.Albums.Add(new Album()
            {
                Artist = new Artist { Name = "Celine Dion" },
                Genre = new Genre { Name = "Soft Rock" },
                Price = 9.99m,
                Title = "The Colour of My Love"
            });

            context.Albums.Add(new Album()
            {
                Artist = new Artist { Name = "Bon Jovi" },
                Genre = new Genre { Name = "80's Hair Band" },
                Price = 9.99m,
                Title = "Slippery When Wet"
            });

            context.Albums.Add(new Album()
            {
                Artist = new Artist {Name = "Def Leppard"},
                Genre = new Genre {Name = "80's Hair Band"},
                Price = 5.99m,
                Title = "Hysteria"
            });

            // Kris Added
            context.Albums.Add(new Album()
            {
                Artist = new Artist { Name = "Petra" },
                Genre = new Genre { Name = "Christian Rock" },
                Price = 9.99m,
                Title = "Petra World Tour"
            });

            base.Seed(context);
        }
    }
}