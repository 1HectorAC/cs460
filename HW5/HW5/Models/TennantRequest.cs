using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class TennantRequest
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(20)]
        public string FirstName { get; set; }

        [Required, StringLength(20)]
        public string LastName { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required, StringLength(20)]
        public string ApartmentName { get; set; }

        [Required]
        public int UnitNumber { get; set; }

        [Required, StringLength(100)]
        public string RequestDescription { get; set; }

     
        public bool AllowEnter { get; set; }

        //add timestamp maker
        public DateTime RequestTimeStamp { get; set; }
        

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} {UnitNumber} {RequestDescription}";
        }
    }
}