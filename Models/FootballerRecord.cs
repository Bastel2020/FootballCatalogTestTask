using Football.DTOs;
using Football.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models
{
    public class FootballerRecord
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        [Required]
        public DateTime DateOfBrith { get; set; }
        [Required]
        public TeamRecord Team { get; set; }
        [Required]
        public CountryEnum Country { get; set; }

        public FootballerRecord() { }

        public FootballerRecord(AddFootballerDTO footballerData, TeamRecord footballerTeam)
        {
            FirstName = footballerData.FirstName;
            SecondName = footballerData.SecondName;
            Gender = EnumMapper.ToGenderEnum(footballerData.Gender);
            DateOfBrith = footballerData.DateOfBrith;
            Country = EnumMapper.ToCountryEnum(footballerData.Country);
            Team = footballerTeam;
        }

        public FootballerRecord(string firstName, string secondName, GenderEnum gender, DateTime dateOfBrith, CountryEnum country, TeamRecord team)
        {
            FirstName = firstName;
            SecondName = secondName;
            Gender = gender;
            DateOfBrith = dateOfBrith;
            Country = country;
            Team = team;
        }

        public string GetGenderString()
        {
            return EnumMapper.GenderToString(Gender);
        }

        public string GetCountryString()
        {
            return EnumMapper.CountryToString(Country);
        }
    }
}
