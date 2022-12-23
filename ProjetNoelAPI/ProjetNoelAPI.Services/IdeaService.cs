using ProjetNoelAPI.Contracts.Services;
using ProjetNoelAPI.Contracts.UnitOfWork;
using ProjetNoelAPI.Models;
using ProjetNoelAPI.Services.Commons;
using System.Net.Mail;
using Azure;
using Azure.Communication.Email;
using Azure.Communication.Email.Models;

namespace ProjetNoelAPI.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IUnitOfWork _uow;

        public IdeaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Idea>> CreateIdea(List<Idea> ideas)
        {
            _uow.IdeaRepository.AddRange(ideas);
            await _uow.CommitAsync();
            return ideas;
        }

        public async Task<Idea> DeleteIdea(int id)
        {
            Idea idea = _uow.IdeaRepository.Get(x => x.Id == id);
            _uow.IdeaRepository.Remove(idea);
            await _uow.CommitAsync();
            return idea;
        }

        public async Task<List<Idea>> GetIdeas(int idListe)
        {
            IEnumerable<Idea> ideas = await _uow.IdeaRepository.GetAllAsync(x => x.IdListe == idListe);
            return ideas.ToList();
        }

        public async void SendMail(List<Idea> ideas)
        {
            Liste liste = await _uow.ListeRepository.GetAsync(ideas[0].IdListe);
            Squad squad = await _uow.SquadRepository.GetAsync(liste.IdSquad);
            //List<User>? users = await _uow.UserRepository.GetAll(x => x.Squades.Where(s => s.Id == squad.Id).SelectMany(s => s.Users).ToList());
            string connectionString = "endpoint=https://giftlistproject.communication.azure.com/;accesskey=ze63g5K/7ugHut+n2+hDwvL2UrgC3VoTLw3nnZytlB6BRO/uf22Y29UIEsU80Yu5wUDzi730UsoR9BN+rPLung==";
            EmailClient emailClient = new EmailClient(connectionString);
            foreach (var idea in ideas)
            {
                if(idea.IsTake == true)
                {
                    EmailContent emailContent = new EmailContent("Nouvel idée coché");
                    emailContent.PlainText = "L'idée " + idea.Name + "a été prise dans la liste " + liste.Name;
                    List<EmailAddress> emailAddresses = new List<EmailAddress> { new EmailAddress("tristandevoille@gmail.com") { DisplayName = "Friendly Display Name" } };
                    EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);
                    EmailMessage emailMessage = new EmailMessage("DoNotReply@af035426-b560-4626-9954-fe5bef914edd.azurecomm.net", emailContent, emailRecipients);

                    try
                    {
                        SendEmailResult emailResult = emailClient.Send(emailMessage, CancellationToken.None);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",ex.ToString());
                    }
                }
            }
        }

        public async Task<List<Idea>> UpdateIdea(List<Idea> ideas)
        {
            _uow.IdeaRepository.UpdateRange(ideas);
            await _uow.CommitAsync();
            return ideas;
        }
    }
}
