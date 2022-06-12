using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace shahzaib.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; } = "";

        [Required]
        [Range(20 , 75 , ErrorMessage ="Currently we dont have a vacant position for your age")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Qualification { get; set; } = "";

        [Required]
        [Range(0 , 25 , ErrorMessage = "Currently We dont have a vacant position for your age")]
        public int TotalExperience { get; set; }

        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();

        public string PhotoUrl { get; set; }
        [Required(ErrorMessage ="Please Choose a profile picture")]
        [Display(Name="Profile Photo")]
        //so that the byte array will not be stored into the database 
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; } 

    }
}
