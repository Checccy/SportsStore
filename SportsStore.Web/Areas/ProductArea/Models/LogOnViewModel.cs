﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsStore.Web.Areas.ProductArea.Models
{
    public class LogOnViewModel
    {
        [Required]
        public  string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get;set; }
    }
}