using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubHub.Models
{
    public class RequestViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Það þarf að fylla inn í þennan reit")]
        [Display(Name = "Nafn")]
        public string Name { get; set; }
        [Display(Name = "Tungumál")]
        public int LanguageId { get; set; }
        public List<SelectListItem> SubtitleLanguages { get; set; }
    }
}