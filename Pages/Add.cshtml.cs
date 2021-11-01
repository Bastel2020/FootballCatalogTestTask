using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Football.Database;
using Football.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Football.DTOs;

namespace Football.Pages
{
    public class AddModel : PageModel
    {
        public string Message { get; private set; }
        public List<string> Teams { get; private set; }
        private IFootballersRepository _footballersRepository;
        private ITeamsRepository _teamsRepository;
        public AddModel(ITeamsRepository teamsRepository, IFootballersRepository footballersRepository)
        {
            _teamsRepository = teamsRepository;
            _footballersRepository = footballersRepository;
            Teams = teamsRepository.GetTeamsNames().Result;
        }
        public async void OnGet()
        {
            Message = "Введите данные о футболисте";
            Teams = (await _teamsRepository.GetTeamsNames());
        }

        public async Task OnPost(AddFootballerDTO data)
        {
            //if(!(Enum.TryParse(typeof(Gender), gender, out object parsedGender) | Enum.TryParse(typeof(Country), country, out object parsedCountry)))
            //{
            //    Message = "Ошибка ввода данных";
            //    return;
            //}
            var result = await _footballersRepository.AddFootballer(data);
            if(result)
                Message = "Данные успешно введены";
            else
                Message = "Ошибка при добавлении данных";
            //db.Footballers.Add(new Footballer(firstName, secondName, (Gender)parsedGender, dateOfBrith, team, (Country)parsedCountry));
            Teams = (await _teamsRepository.GetTeamsNames());
            //db.SaveChanges();

        }
    }
}
