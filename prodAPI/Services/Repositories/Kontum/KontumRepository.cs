using AutoMapper;
using Microsoft.EntityFrameworkCore;

using prodAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace prodAPI.Services
{
    public class KontumRepository : IKontumRepository
    {
        private production_dbContext _context;
        private readonly IMapper _mapper;

        //ADD HASHING PASSWORDS
        public static ulong GetUInt64Hash(HashAlgorithm hasher, string text)
        {
            using (hasher)
            {
                var bytes = hasher.ComputeHash(Encoding.Default.GetBytes(text));
                Array.Resize(ref bytes, bytes.Length + bytes.Length % 8); //make multiple of 8 if hash is not, for exampel SHA1 creates 20 bytes. 
                return Enumerable.Range(0, bytes.Length / 8) // create a counter for de number of 8 bytes in the bytearray
                    .Select(i => BitConverter.ToUInt64(bytes, i * 8)) // combine 8 bytes at a time into a integer
                    .Aggregate((x, y) => x ^ y); //xor the bytes together so you end up with a ulong (64-bit int)
            }
        }


        public KontumRepository(production_dbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<KontumDto?> GetKontumAsync(int IdKonta)
        {
            return await _context.Konties.Where(c => c.IdKonta == IdKonta).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<KontumDto>> GetKontumAsync()
        {
            return await _context.Konties.ToListAsync();
        }

        public async Task AddKontoAsync(KontumCreationDto konto)
        {

            var newKonto = _mapper.Map<KontumDto>(konto);
            await _context.Konties.AddAsync(newKonto);
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
