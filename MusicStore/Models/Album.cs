using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MusicStore.Models
{
    [Bind(Exclude = "AlbumID")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public virtual int AlbumID { get; set; }

        [DisplayName("Genre")]
        public virtual int GenreID { get; set; }

        [DisplayName("Artist")]
        public virtual int ArtistID { get; set; }

        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public virtual string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
        ErrorMessage = "Price must be between 0.01 and 100.00")]
        public virtual decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public virtual string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        

    }
}