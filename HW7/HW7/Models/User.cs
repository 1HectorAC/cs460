using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        [Required, StringLength(200)]
        public string RequestedWord { get; set; }

        [Required]
        public string RequestorsIPAddress { get; set; }

        [Required]
        public string RequestorsBrowser { get; set; }

    }
}