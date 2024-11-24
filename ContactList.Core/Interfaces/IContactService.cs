namespace ContactList.Core.Interfaces;

using ContactList.Domain.Entities;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetContactsAsync(int page, int pageSize);

    Task<Contact?> GetContactByIdAsync(Guid id);

    Task AddContactAsync(Contact contact);

    Task UpdateContactAsync(Contact contact);

    Task DeleteContactAsync(Guid id);
}

