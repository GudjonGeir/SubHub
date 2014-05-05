using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string DateSubmitted { get; set; }
        public bool Completed { get; set; }
    }
}