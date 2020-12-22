using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationValidationFinSub.Models
{
    public class BookCatalogModel
    {
        public int ID { get; set; }
        
        [DisplayName("Book Name")]
        [Required(ErrorMessage ="Book Name Required")]
        public string Name { get; set; }

        [DisplayName("Book Summary")]
        public string Summary { get; set; }


        [DisplayName("ISBN No.")]
        [StringLength(13,MinimumLength =13,ErrorMessage ="It must be 13 characters")]
        [Required(ErrorMessage = "Enter 13 Digit ISBN")]
        public string ISBN { get; set; }

        [DisplayName("Auther Name")]
        public string Author { get; set; }


        [DisplayName("Publication Year: ")]
        [Range(1800,2020,ErrorMessage ="Enter Year(1800-2020)")]
        [Required(ErrorMessage = "Publication Year Required")]
        public int Publication { get; set; }

        [DisplayName("Location Code")]
        [Required(ErrorMessage = "Book location code Required")]
        public string LocCode { get; set; }
    }
}