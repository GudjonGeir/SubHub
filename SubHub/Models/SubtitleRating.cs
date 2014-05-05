using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class SubtitleRating
    {
        public int Id { get; set; }
        public List<int> UserIds { get; set; }
        public int SubtitleId { get; set; }
        public int Count { get; set; }
    }
}