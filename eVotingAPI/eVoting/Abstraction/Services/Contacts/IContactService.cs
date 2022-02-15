using eVoting.App.Models;
using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Contacts
{
    public interface IContactService
    {
        Task AddMessageAsync(Contact contact);

        Task<int> SaveChanges();
    }
}
