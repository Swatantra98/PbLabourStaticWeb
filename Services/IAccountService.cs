using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PbLabourStatic.Helpers;
using PbLabourStatic.Models;


namespace PbLabourStatic.Services
{
    public interface IAccountService
    {
        Task<List<Officers>> GetOfficerByRole(string Role);

    }

    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Officers>> GetOfficerByRole(string Role)
        {
            if (Role == "ADF/DDF")
            {
                return await _context.Officers.Where(x => x.OfficerRole == OfficerType.DF).OrderBy(x => x.OfficerName).ToListAsync();
            }
            else if (Role == "ALC/LCO")
            {
                return await _context.Officers.Where(x => x.OfficerRole == OfficerType.LC).OrderBy(x => x.OfficerName).ToListAsync();
            }
            else
            {
                return await _context.Officers.Where(x => x.OfficerRole == OfficerType.LEO).OrderBy(x => x.OfficerName).ToListAsync();
            }
        }
    }
}
