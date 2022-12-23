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

            User user = await _uow.UserRepository.GetAsync(x => x.Id == int.Parse(id));

            liste.IdCreator = user.Id;

            _uow.ListeRepository.Add(liste);
            await _uow.CommitAsync();

            return liste;


        }

        public async Task<bool> DeleteListe(string? token, int idListe)
        {
            string id = GetParamToken.GetClaimInToken(token, "id");

            User? userverify = await _uow.UserRepository.GetAsync(x => x.Id == int.Parse(id));
            Liste? liste = await _uow.ListeRepository.GetAsync(x => x.Id == idListe);

            if (liste?.IdCreator == userverify?.Id)
                _uow.ListeRepository.Remove(liste);
            else
                return false;

            await _uow.CommitAsync();
            return true;


        }

        public List<Liste> GetListe(int idSquad)
        {
            IEnumerable<Liste> listes = _uow.ListeRepository.GetAll(x => x.IdSquad == idSquad);
            return listes.ToList();

        }

        public Liste GetListeWithIdListe(int idListe)
        {
            Liste liste = _uow.ListeRepository.Get(x => x.Id == idListe);
            return liste;
        }

        public async Task<bool> UpdateListe(Liste liste)
        {
            _uow.ListeRepository.Update(liste);
            await _uow.CommitAsync();
            return true;
        }
    }
}
