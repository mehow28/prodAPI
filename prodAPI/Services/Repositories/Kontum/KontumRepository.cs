using Microsoft.EntityFrameworkCore;

using prodAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace prodAPI.Services
{
    public class KontumRepository : IKontumRepository
    {
        private production_dbContext _context;


        //ADD HASHING PASSWORDS
        public string getHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA512.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }


        public KontumRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<KontumDto?> GetKontumAsync(int IdKonta)
        {
            return await _context.Konties.Where(c=>c.IdKonta==IdKonta).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<KontumDto>> GetKontumAsync()
        {
            return await _context.Konties.ToListAsync();
        }

        public async Task AddKontoAsync(KontumDto konto)
        {
           _context.Konties.Add(konto);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteKonto(KontumDto konto)
        {
            _context.Konties.Remove(konto);
        }


    }
}
