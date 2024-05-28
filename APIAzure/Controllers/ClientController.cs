using APIAzure.Data;
using APIAzure.Data.BankModels;
using APIAzure.DTO;
using APIAzure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAzure.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly BankAPIAzureContext _context;
        public ClientController(BankAPIAzureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.ToList();
        }
        [HttpGet("{id}")]
        public Client GetClientsById(int id)
        {
            return _context.Clients.ToList().Find(x => x.Id == id);
        }
        [HttpPost]
        public IActionResult PostClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetClientsById), new { id = client.Id }, client);
        }
    }
}