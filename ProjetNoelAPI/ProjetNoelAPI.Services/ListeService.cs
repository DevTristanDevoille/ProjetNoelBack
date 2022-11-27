using Microsoft.IdentityModel.Tokens;
using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetNoelAPI.Services
{
    public class ListeService : IListeService
    {

        private readonly IUnitOfWork _uow;
        public ListeService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<Liste> CreateListe(Liste liste,string? token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(token);
            JwtSecurityToken tokenS = jsonToken as JwtSecurityToken;
            string id = tokenS.Claims.First(claim => claim.Type == "id").Value;

            //User user = _context.Users.FirstOrDefault(u => u.Id.ToString() == id);

            //liste.Users.Add(user);
            //liste.IdCreator = user.Id;

            _uow.ListeRepository.Add(liste);
            _uow.Commit();

            return liste;


        }

        public async Task<bool> DeleteListe(string? token, int? idListe)
        {
            JwtSecurityTokenHandler? handler = new JwtSecurityTokenHandler();
            SecurityToken? jsonToken = handler.ReadToken(token);
            JwtSecurityToken? tokenS = jsonToken as JwtSecurityToken;
            string id = tokenS.Claims.First(claim => claim.Type == "id").Value;


            //User? userverify = _context.Users.FirstOrDefault(u => u.Id.ToString() == id);
            //Liste? liste = _context.Listes.FirstOrDefault(l => l.Id == idListe);

            //if (liste?.IdCreator == userverify?.Id)
            //    _uow.ListeRepository.Remove(liste);
            //else
            //    return false;

            _uow.Commit();
            return true;


        }

        public async Task<List<Liste>> GetListe(string? token)
        {
            JwtSecurityTokenHandler? handler = new JwtSecurityTokenHandler();
            SecurityToken? jsonToken = handler.ReadToken(token);
            JwtSecurityToken? tokenS = jsonToken as JwtSecurityToken;
            string? id = tokenS?.Claims.First(claim => claim.Type == "id").Value;

            //List<Liste> listes = _context.Users.Where(u => u.Id.ToString() == id).SelectMany(u => u.Listes).ToList();

            List<Liste> listes = new ();

            return listes;

        }

        public async Task<bool> UpdateListe(Liste liste, string? token)
        {
            JwtSecurityTokenHandler? handler = new JwtSecurityTokenHandler();
            SecurityToken? jsonToken = handler.ReadToken(token);
            JwtSecurityToken? tokenS = jsonToken as JwtSecurityToken;
            string? id = tokenS?.Claims.First(claim => claim.Type == "id").Value;

            return true;
        }
    }
}
