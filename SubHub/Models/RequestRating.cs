using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class RequestRating
    {
        public int Id { get; set; }
        public List<int> UserId { get; set; }
        public int count {get; set; }
    }
}