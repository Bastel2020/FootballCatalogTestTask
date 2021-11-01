using Football.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football.DTOs
{
    public class AddFootballerDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Team { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBrith { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
