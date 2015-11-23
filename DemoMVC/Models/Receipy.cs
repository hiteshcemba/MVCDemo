using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class Receipy
    {

        [Display(Name = "ID #")]
        public int ReceipyID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string ReceipyName { get; set; }
        
        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Ingredients { get; set; }

        [StringLength(5000)]
        [DataType(DataType.MultilineText)]
        public string Making { get; set; }

        [Display(Name = "Time")]
        public int TimeToMake   { get; set; }

        [Display(Name = "Insert")]
        public DateTime  DateInsert { get; set; }
         [Display(Name = "Update")]
        public DateTime DateUpdate { get; set; }
       
        public string Image { get; set; }
        public string ImageURL { 
            get
                {
                    return "~\\Content\\Images\\" + Image;
                }
             }

        [Display(Name = "SubCategory")]
        public int SubCategoryID { get; set; }
        public virtual SubCategory  SubCategory { get; set; }
        public Receipy()
        {
            SubCategory = new SubCategory();
        }
    }
}