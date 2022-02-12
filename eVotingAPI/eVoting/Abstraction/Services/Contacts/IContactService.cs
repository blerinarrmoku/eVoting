using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Contacts
{
    public interface IContactService
    {
        Task AddMessageAsync();

        Task<int> SaveChanges();
    }
}
