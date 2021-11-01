using Football.DTOs;
using Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Interfaces
{
    public interface IFootballersRepository
    {
        public Task<List<FootballerRecord>> GetAllFootballers();
        public Task<FootballerRecord> GetFootballerById(int footballerId);
        public Task<bool> AddFootballer(AddFootballerDTO footballerToAdd);
        public Task<bool> EditFootballer(EditFootballerDTO footballerToAdd);
        public Task<bool> DeleteFootballer(int footballerId);
    }
}
