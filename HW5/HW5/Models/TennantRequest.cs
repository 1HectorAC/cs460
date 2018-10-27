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

        [Required, StringLength(20), Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Phone, Display(Name = "Phone Number"), RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number. Use only Numbers. Format:xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(20), Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }

        [Required, Display(Name = "Unit Number"), Range(0,1000)]
        public int UnitNumber { get; set; }

        [Required, StringLength(600), Display(Name = "Description of request")]
        public string RequestDescription { get; set; }

        public bool AllowEnter { get; set; }

        public DateTime RequestTimeStamp { get; set; }
        

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} {UnitNumber} {RequestDescription}";
        }
    }
}