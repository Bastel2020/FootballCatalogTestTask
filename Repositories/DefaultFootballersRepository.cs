using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.Database;
using Football.DTOs;
using Football.Interfaces;
using Football.Models;
using Microsoft.EntityFrameworkCore;
using Football.Models.Enums;

namespace Football.Repositories
{
    public class DefaultFootballersRepository : IFootballersRepository
    {
        private readonly DefaultDbContext _db;
        private readonly ITeamsRepository _teamsRepo;
        public DefaultFootballersRepository(DefaultDbContext db, ITeamsRepository teamsRepo)
        {
            _db = db;
            _teamsRepo = teamsRepo;
        }

        public async Task<List<FootballerRecord>> GetAllFootballers()
        {
            return await _db.Footballers
                .Include(f => f.Team)
                .OrderBy(f => f.Id)
                .ToListAsync();
        }

        public async Task<FootballerRecord> GetFootballerById(int footballerId)
        {
            return (await GetAllFootballers())
                .FirstOrDefault(f => f.Id == footballerId);
        }

        public async Task<bool> AddFootballer(AddFootballerDTO footballerToAdd)
        {
            var footballerTeam = await _teamsRepo.ContainsTeam(footballerToAdd.Team);

            if (footballerTeam == null)
            {
                footballerTeam = await _teamsRepo.CreateTeam(footballerToAdd.Team);
            }

            await _db.Footballers.AddAsync(new FootballerRecord(footballerToAdd, footballerTeam));

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditFootballer(EditFootballerDTO footballerData)
        {
            var footballerToEdit = await GetFootballerById(footballerData.EditId);

            if (footballerToEdit == null)
                return false;

            if (footballerData.FirstName != null && footballerData.FirstName != "")
                footballerToEdit.FirstName = footballerData.FirstName;

            if (footballerData.SecondName != null && footballerData.SecondName != "")
                footballerToEdit.SecondName = footballerData.SecondName;

            if (footballerData.Country != null && footballerData.Country != "")
                footballerToEdit.Country = EnumMapper.ToCountryEnum(footballerData.Country);

            if (footballerData.Gender != null && footballerData.Gender != "")
                footballerToEdit.Gender = EnumMapper.ToGenderEnum(footballerData.Gender);

            if (footballerData.DateOfBrith != new DateTime())
                footballerToEdit.DateOfBrith = footballerData.DateOfBrith;

            if (footballerData.Team != null && footballerData.Team != "")
            {
                var newTeam = await _teamsRepo.ContainsTeam(footballerData.Team);

                if (newTeam == null)
                    newTeam = await _teamsRepo.CreateTeam(footballerData.Team);

                footballerToEdit.Team = newTeam;
            }

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFootballer(int footballerId)
        {
            var footballerToDelete = await _db.Footballers.FirstOrDefaultAsync(f => f.Id == footballerId);
            if (footballerToDelete == null)
                return false;

            _db.Footballers.Remove(footballerToDelete);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
