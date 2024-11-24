using ContactList.Domain.Entities;

namespace ContactList.Infrastructure.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetContactsAsync(int page, int pageSize);
    Task<Contact?> GetContactByIdAsync(Guid id);
    Task AddContactAsync(Contact contact);
    Task UpdateContactAsync(Contact contact);
    Task DeleteContactAsync(Guid id);
}