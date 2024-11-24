using ContactList.Core.Interfaces;
using ContactList.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("contacts")]
        public async Task<IActionResult> GetContacts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var contacts = await _service.GetContactsAsync(page, pageSize);

                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("contacts/{id}")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            try
            {
                var contact = await _service.GetContactByIdAsync(id);

                return contact == null ? NotFound() : Ok(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("contacts")]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            try
            {
                await _service.AddContactAsync(contact);

                return Ok(contact.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("contacts/{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] Contact contact)
        {
            if (id != contact.Id)
                return BadRequest();

            try
            {
                await _service.UpdateContactAsync(contact);

                return Ok(new { Message = "Contact updated successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("contacts/{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            try
            {
                await _service.DeleteContactAsync(id);

                return Ok(new { Message = "Contact delected successfully" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
