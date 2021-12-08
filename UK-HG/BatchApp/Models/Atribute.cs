using System;
using System.ComponentModel.DataAnnotations;

namespace BatchApp.Models
{
    public class Atribute
    { 
        [Key]
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }

    }
}
