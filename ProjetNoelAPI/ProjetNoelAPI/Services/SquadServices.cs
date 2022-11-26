﻿using Microsoft.IdentityModel.Tokens;
using ProjetNoelAPI.Interfaces;
using ProjetNoelAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.IO;

namespace ProjetNoelAPI.Services
{
    public class SquadServices : ISquadServices
    {
        private readonly NoelDbContext? _context;

        public SquadServices(NoelDbContext context)
        {
            _context = context;
        }

        public async Task<string>? CreateSquad(string token)
        {

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(token);
            JwtSecurityToken tokenS = jsonToken as JwtSecurityToken;
            string id = tokenS.Claims.First(claim => claim.Type == "id").Value;

            User user = _context.Users.FirstOrDefault(u => u.Id.ToString() == id);
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

            _context.Squades.Add(squad);
            _context.SaveChanges();

            return resultString;
        }

        public async Task<bool> FindSquad(string? code,string? token)
        {

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(token);
            JwtSecurityToken tokenS = jsonToken as JwtSecurityToken;
            string id = tokenS.Claims.First(claim => claim.Type == "id").Value;

            User user = _context.Users.FirstOrDefault(u => u.Id.ToString() == id);

            if (user == null)
                return false;

            List<User> userInSquad = _context?.Squades?.Where(s => s.Code == code).SelectMany(s => s.Users).ToList();

            Squad? squad = _context?.Squades?.FirstOrDefault(s => s.Code == code);

            if (userInSquad == null || userInSquad.Contains(user))
                return false;

            squad.Users = new List<User> { user };
            _context?.Squades?.Update(squad);
            _context?.SaveChanges();

            return true;
        }
    }
}
