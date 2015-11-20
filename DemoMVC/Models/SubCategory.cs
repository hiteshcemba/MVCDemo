using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required]
        [Display(Name = "SubCategory")]
        public string SubCategoryName { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}