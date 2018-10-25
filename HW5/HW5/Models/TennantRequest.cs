using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class TennantRequest
    {

        [Required, StringLength(20)]
        public string FirstName { get; set; }

        [Required, StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required, StringLength(20)]
        public string ApartmentName { get; set; }

        [Required]
        public int UnitNumber { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }

        //add timestamp maker

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} {UnitNumber} {Description}";
        }
    }
}