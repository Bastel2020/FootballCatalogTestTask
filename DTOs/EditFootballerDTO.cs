using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.DTOs
{
    public class EditFootballerDTO
    {
        public int EditId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Team { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBrith { get; set; }
        public string Country { get; set; }
    }
}
