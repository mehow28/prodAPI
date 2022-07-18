using AutoMapper;
using prodAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace prodAPI.Profiles
{
    
    public class KontumProfile : Profile
    {
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
        public KontumProfile()
        {

            CreateMap<KontumCreationDto, KontumDto>();
            CreateMap<string, byte[]>().ConvertUsing(
                s=> BitConverter.GetBytes(GetUInt64Hash(SHA256.Create(), s)));
            CreateMap<KontumUpdateDto, KontumDto>();
            CreateMap<KontumDto, KontumUpdateDto>();

        }
    }
}
