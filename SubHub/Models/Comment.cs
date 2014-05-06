using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Repositories
{
    public class Comment
    {
        public          int         Id              { get; set; }
        public          string      CommentText     { get; set; }
        public          DateTime    DateSubmitted   { get; set; }
    }
}