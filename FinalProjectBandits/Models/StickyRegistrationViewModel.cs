using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FinalProjectBandits.Models
{
    public class StickyRegistrationViewModel
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public CategoryList Category { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }

    public enum CategoryList
    {
        Physical,
        Financial,
        Items,
        Learning,
        Transportation,
        HomeCare
    }
}