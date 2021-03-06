﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "UserId")]
        [StringLength(10)]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10)]
        [Display(Name = "Password")]
        public string Password { get; set; }

     
    }
}