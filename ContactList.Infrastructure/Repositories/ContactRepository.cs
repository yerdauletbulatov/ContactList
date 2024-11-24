using ContactList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public ContactRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetContactsAsync(int page, int pageSize)
    {
        return await _context.Contacts
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Contact?> GetContactByIdAsync(Guid id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task AddContactAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContactAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContactAsync(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}

