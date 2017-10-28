using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();

        //
        // GET: /StoreManager/

        //public ActionResult Index()
        //{
        //    var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
        //    return View(albums.ToList());
        //}

        public ActionResult Index()
        {
            var albums = db.Albums.ToList();
            //var genres = db.Genres.ToList();
            //return View(genres);

            //var albums = new List<Album>
            //{
            // new Album { Title = "Slippery When Wet", AlbumID=1},
            // new Album { Title = "Petra World Tour", AlbumID=2},
            // new Album { Title = "The Colour of My Love", AlbumID=3},
            // new Album { Title = "Hysteria", AlbumID=4}
            //};

            // NOTE: This will not work because the Index view takes a IEnumerable<MusicStore.Models.Album> or List<Album> 
            // this is trying to send List<Genre>. Look at what was being sent in the Index method above.
            return View(albums);
        }

        
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        //public ActionResult Browse(string genre)
        //{
        //     Retrieve Genre and its Associated Albums from database
        //    var genreModel = db.Genres.Include("Albums")
        //    .Single(g => g.Name == genre);
        //    return View(genreModel);
        //}

        //
        // GET: /StoreManager/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Album album = db.Albums.Find(id);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", album.GenreID);
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", album.ArtistID);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}