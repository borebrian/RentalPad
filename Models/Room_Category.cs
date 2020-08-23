using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalPad.Models
{
    public class Room_Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room category", Prompt = "Room category")]
        public int Category { get; set; }

        [Required]
        [Display(Name = "Rent Ammount", Prompt = "Rent Ammount")]
        [DataType(DataType.Currency)]
        public String Rent_Ammount { get; set; }
    }
}
