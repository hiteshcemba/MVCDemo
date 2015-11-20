using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace DemoMVC.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }
        [Required]
        [Display(Name = "SubCategory")]
        [StringLength(50)]
        public string SubCategoryName { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public virtual Category  Category { get; set; }
        public SubCategory()
        {
            Category = new Category();
        }

    }

    public class SubCategoryDBContext : DbContext
    {

        public System.Data.Entity.DbSet<DemoMVC.Models.SubCategory> SubCategories { get; set; }

        public System.Data.Entity.DbSet<DemoMVC.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<DemoMVC.Models.Receipy> Receipies { get; set; }
    }


}