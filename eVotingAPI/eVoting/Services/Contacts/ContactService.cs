using eVoting.App.Abstraction.Services.Contacts;
using eVoting.App.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eVoting.App.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly ILogger<ContactService> _logger;
        private readonly EVotingContext _context;

        public ContactService(ILogger<ContactService> logger,
                              EVotingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task AddMessageAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
