using APIAzure.Data;
using APIAzure.Data.BankModels;
using APIAzure.DTO;
using Microsoft.EntityFrameworkCore;

namespace APIAzure.Services
{
    public class LoginService
    {
        private readonly BankAPIAzureContext _context;
        public LoginService(BankAPIAzureContext context) { 
            _context = context;
        }

        public async Task<Administrator?>  GetAdministrator(AdminDto admin)
        {
            return await _context.Administrators.SingleOrDefaultAsync(x=> x.Email ==admin.Email && x.Pwd == admin.Pwd);
        }
    }
}
