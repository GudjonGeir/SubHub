using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class User
    {
        public         int                          Id { get; set; }
        public         string                       UserName { get; set; }
        public         string                       Email { get; set; }
        public         string                       Password { get; set; }
        public         string                       Name { get; set; }
        public         DateTime                     DateCreated { get; set; }
        public virtual ICollection<Comment>         Comments { get; set; }  // List of comments user has made
        [InverseProperty("Users")]
        public virtual ICollection<RequestRating>   RequestRatings { get; set; }  // List of request ratings user has made
        public virtual ICollection<SubtitleRating>  SubtitleRatings { get; set; }    // List of subtitle ratings user has made
        public virtual ICollection<Subtitle>        Subtitles { get; set; }    // List of subtitles user has edited
        public virtual ICollection<Request>         Requests { get; set; }  // Requests the user has made
    }
}