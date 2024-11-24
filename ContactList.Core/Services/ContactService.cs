using ContactList.Core.Interfaces;
using ContactList.Domain.Entities;
using ContactList.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace ContactList.Core.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;
    private readonly ILogger<ContactService> _logger;

    public ContactService(IContactRepository repository, ILogger<ContactService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<Contact>> GetContactsAsync(int page, int pageSize)
    {
        _logger.LogInformation("Fetching contacts (Page: {Page}, PageSize: {PageSize})", page, pageSize);

        var contacts = await _repository.GetContactsAsync(page, pageSize);

        if (contacts == null)
        {
            _logger.LogWarning("Repository returned null. Returning an empty list.");
            return new List<Contact>();
        }

        _logger.LogInformation("Fetched {Count} contacts", contacts.Count());

        return contacts;
    }

    public async Task<Contact?> GetContactByIdAsync(Guid id)
    {
        _logger.LogInformation("Fetching contact by ID: {Id}", id);

        var contact = await _repository.GetContactByIdAsync(id);

        if (contact == null)
            _logger.LogWarning("Contact with ID: {Id} not found", id);

        return contact;
    }

    public async Task AddContactAsync(Contact contact)
    {
        _logger.LogInformation("Adding new contact: {Contact}", contact);

        await _repository.AddContactAsync(contact);
        _logger.LogInformation("Successfully added contact with ID: {Id}", contact.Id);
    }

    public async Task UpdateContactAsync(Contact contact)
    {
        _logger.LogInformation("Updating contact with ID: {Id}", contact.Id);

        await _repository.UpdateContactAsync(contact);
        _logger.LogInformation("Successfully updated contact with ID: {Id}", contact.Id);
    }

    public async Task DeleteContactAsync(Guid id)
    {
        _logger.LogInformation("Deleting contact with ID: {Id}", id);

        await _repository.DeleteContactAsync(id);
        _logger.LogInformation("Successfully deleted contact with ID: {Id}", id);
    }
}