using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPad.Models
{
    public class Rentals_reg
    {
        [Key]
        public int id { get; set; }


        [ForeignKey("National_id")]
        [Required]
        [Display(Name = "National id", Prompt = "National id")]
        public int National_id { get; set; }
        public Rental_Owners Rental_Owners { get; set; }

        [Required]
        [Display(Name = "Rental name", Prompt = "Rental name")]

        public string R_name { get; set; }
        [Required]
        [Display(Name = "Rental location", Prompt = "Rental location")]
        public string  R_location { get; set; }

        [Required]
        [Display(Name = "No. of rooms", Prompt = "No of rooms")]
        public int No_rooms { get; set;}


    }
}
