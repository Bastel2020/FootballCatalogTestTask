using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Football.Interfaces;
using Football.Models;
using Football.Models.Enums;
using Football.DTOs;

namespace Football.Pages
{
    public class ShowFootballersModel : PageModel
    {
        public string Message { get; private set; }
        public IFootballersRepository footballersRepository { get; private set; }
        public ITeamsRepository teamsRepository { get; private set; }
        public int FootballerToEditId { get; private set; }
        public List<FootballerRecord> FootballersTable { get; private set; }

        public ShowFootballersModel(IFootballersRepository footballersRepo, ITeamsRepository teamsRepo)
        {
            footballersRepository = footballersRepo;
            teamsRepository = teamsRepo;
        }
        public async Task OnGet(int id, bool delete)
        {
            Message = "Список всех футболистов";
            if (delete)
            {
                if (await footballersRepository.DeleteFootballer(id))
                    Message = "Футболист успешно удалён";
                else
                    Message = "Ошибка при удалении футболиста";
            }
            FootballerToEditId = id;
            FootballersTable = await footballersRepository.GetAllFootballers();
        }

        public async Task OnPost(EditFootballerDTO data)
        {
            var resultStatus = await footballersRepository.EditFootballer(data);
            if (resultStatus)
                Message = "Данные футболиста успешно изменены";
            else
                Message = "Ошибка при изменении данных футболиста";

            FootballersTable = await footballersRepository.GetAllFootballers();
        }
    }
}
