using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubHub.Repositories
{
    public class Request
    {
        public         int              Id              { get; set; }
        public         string           Name            { get; set; }
        public         DateTime         DateSubmitted   { get; set; }
        public         bool             Completed       { get; set; }
        // public         int              UserId          { get; set; }
        public virtual RequestRating RequestRating { get; set; }   // Corresponding rating for the request
    }
}