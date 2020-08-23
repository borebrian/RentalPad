using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPad.Models
{
    public class Rooms_reg
    {
        [Key]
        public int id { get; set; }


        //[ForeignKey("id")]
        [Required]
        [Display(Name = "Rental no", Prompt = "Rental no")]
        public int Rental_reg { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Room number", Prompt = "Room number")]
        public String Room_number { get; set; }

        [Required]
        [Display(Name = "Room category", Prompt = "Room category")]
        public String Room_category { get; set; }

      

    }
}
