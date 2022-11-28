using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.Models;
using ProjetNoelAPI.Services.Commons;

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
            string id = GetParamToken.GetClaimInToken(token, "id");

            User user = await _uow.UserRepository.GetAsync(int.Parse(id));

            liste?.Users?.Add(user);
            liste.IdCreator = user.Id;

            _uow.ListeRepository.Add(liste);
            _uow.Commit();

            return liste;


        }

        public async Task<bool> DeleteListe(string? token, int idListe)
        {
            string id = GetParamToken.GetClaimInToken(token, "id");

            User? userverify = await _uow.UserRepository.GetAsync(int.Parse(id));
            Liste? liste = await _uow.ListeRepository.GetAsync(idListe);

            if (liste?.IdCreator == userverify?.Id)
                _uow.ListeRepository.Remove(liste);
            else
                return false;

            _uow.Commit();
            return true;


        }

        public async Task<List<Liste>> GetListe(string? token)
        {
            string id = GetParamToken.GetClaimInToken(token, "id");
            List<Liste> listes = _uow.UserRepository.GetListesForUser(int.Parse(id));
            return listes;

        }

        public async Task<bool> UpdateListe(Liste liste, string? token)
        {
            string id = GetParamToken.GetClaimInToken(token, "id");

            _uow.ListeRepository.Update(liste);
            _uow.Commit();

            return true;
        }
    }
}
