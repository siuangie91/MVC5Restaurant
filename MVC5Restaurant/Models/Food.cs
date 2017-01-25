using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Restaurant.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(3.00, Double.MaxValue, ErrorMessage = "Price must be at least $3.00")]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "New Image")]
        public string File { get; set; }

        //public virtual ICollection<FileDetail> File { get; set; }
    }
}