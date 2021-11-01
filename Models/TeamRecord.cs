using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models
{
    public class TeamRecord
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        public List<FootballerRecord> Footballers { get; set; }

        public TeamRecord() { }

        public TeamRecord(string name)
        {
            Name = name;
            Footballers = new List<FootballerRecord>();
        }

        public TeamRecord(string name, IEnumerable<FootballerRecord> footballersToAdd)
        {
            Name = name;
            Footballers = new List<FootballerRecord>(footballersToAdd);
        }
    }
}
