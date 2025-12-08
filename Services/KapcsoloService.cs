using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;

namespace EtteremApi.Services
{
    public class KapcsoloService : IKapcsolo
    {
        private readonly RestaurantContext _context;
        public KapcsoloService(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<object> GetAll()
        {
            try
            {
                var result = new ResultResponseDto();
                var kapcs = _context.Kapcsolos.ToList();
                if(kapcs != null && kapcs.Count > 0)
                {
                    result.Message = "Sikeres lekérdezés";
                    result.result = kapcs;
                    return result;
                }
                result.Message = "Nincs rekord";
                result.result = kapcs;
                return result;
            }
            catch (Exception)
            {
                var result = new ResultResponseDto();
                result.Message = "Hiba a lekérdezés során";
                return result;
            }
            
        }
    }
}
