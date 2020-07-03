using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class mvcPhoneModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Model { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string GeneralNote { get; set; }
    }
}