using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class Receipy
    {

        public int ReceipyID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Receipy Name")]
        public string ReceipyName { get; set; }
        
        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }

        [StringLength(5000)]
        [DataType(DataType.MultilineText)]
        public string Making { get; set; }
        
        public int Time { get; set; }

        public DateTime  DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
       
        public string Image { get; set; }

        [Display(Name = "SubCategory")]
        public int SubCategoryID { get; set; }
        public virtual SubCategory  SubCategory { get; set; }
        public Receipy()
        {
            SubCategory = new SubCategory();
        }
    }
}