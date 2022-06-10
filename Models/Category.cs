﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shahzaib.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required]
        public string categoryName { get; set; }

        [DisplayName("Display Order")]
        [Required]
        [Range(1 , int.MaxValue , ErrorMessage ="Display Order for Category must be greater than 0")]
        public int DisplayOrder { get; set; }




    }
}
