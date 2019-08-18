using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class Customer
    {
        [Required]
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        public string CustomerCode { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerName { get; set; }
    }
}
//Lab 8: For Data Annotation This File is used
// CustomerCode and CustomerName is required
//CustomerName > 10 characters
//CustomerCode should be like ABC1234, GHY7890, JUI8765