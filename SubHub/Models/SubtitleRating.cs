using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubHub.Repositories
{
    public class SubtitleRating
    {
        [Key]
        public int SubtitleId { get; set; }
        public          int               Count         { get; set; }    
        public virtual  Subtitle          Subtitle      { get; set; }   // Corresponding subtitle for the rating
    }
}