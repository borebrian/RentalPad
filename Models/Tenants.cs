using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPad.Models
{
    public class Tenants
    {
        [Key]
        [Required]
        [Display(Name = "National Id", Prompt = "e.g. 12345678")]
        public int National_id { get; set; }

        [Required]
        [Display(Name = "Full names", Prompt = "Full names")]
        [MaxLength(50)]
        public string Full_names { get; set; }

        [Required]
        [Display(Name = "Phone number", Prompt = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public int Phone_number { get; set; }

        [Required]
        [Display(Name = "Location", Prompt = "Location")]
        public string Location { get; set; }

    }
}
