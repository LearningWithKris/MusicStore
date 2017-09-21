using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Artist
    {
        public virtual int ArtistID { get; set; }
        public virtual string Name { get; set;}

    }
}