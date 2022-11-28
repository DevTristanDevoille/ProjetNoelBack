﻿using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.Models;
using ProjetNoelAPI.Services.Commons;

namespace ProjetNoelAPI.Services
{
    public class SquadService : ISquadService
    {
        private readonly IUnitOfWork _uow;

        public SquadService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string>? CreateSquad(string token)
        {

            string id = GetParamToken.GetClaimInToken(token, "id");

            User user = await _uow.UserRepository.GetAsync(int.Parse(id));

            if (user == null)
                return "";

            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new string(Charsarr);

            Squad squad = new Squad() { Users = new List<User>() { user},Code = resultString };

            _uow.SquadRepository.Add(squad);
            await _uow.CommitAsync();

            return resultString;
        }

        public async Task<bool> FindSquad(string? code,string? token)
        {
            string id = GetParamToken.GetClaimInToken(token, "id");

            User user = _uow.UserRepository.Get(int.Parse(id));

            if (user == null)
                return false;

            List<User> userInSquad = _uow.UserRepository.GetUserInSquad(code);
            
            Squad squad = await _uow.SquadRepository.GetAsync(RequestExpression<Squad>.CreateRequetWithOneParam("Code", code));

            if (squad == null || userInSquad.Contains(user))
                return false;

            squad.Users = new List<User> { user };
            _uow.SquadRepository.Update(squad);
            await _uow.CommitAsync();

            return true;
        }
    }
}