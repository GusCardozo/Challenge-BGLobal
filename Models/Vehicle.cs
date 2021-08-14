using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.BGLobal.Models
{
    public class Vehicle
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        public string Patent { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public string Titular { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
