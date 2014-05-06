using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class SubtitleRating
    {
        public          int               Id            { get; set; }
        public          int               Count         { get; set; }
        public          int               SubtitleId    { get; set; }
        public virtual  Subtitle          Subtitle      { get; set; }   // Corresponding subtitle for the rating
        public virtual  ICollection<User> Users         { get; set; }   // Users who have rated
    }
}