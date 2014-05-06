using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class RequestRating
    {
        public         int              RequestId   { get; set; }
        //public         int               Id         { get; set; }
        public         int               count      { get; set; } 
        public virtual Request           Request    { get; set; }    // Corresponding request for the rating
        public virtual ICollection<User> Users      { get; set; }    // Users who have rated corresponding request
    }
}