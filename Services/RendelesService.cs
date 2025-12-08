using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services.IServices;

namespace EtteremApi.Services
{
    public class RendelesService : IRendeles
    {
        private readonly RestaurantContext _context;
        public RendelesService(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewRendeles(AddRendelesDto addRendelesDto)
        {
            try
            {
                var result = new ResultResponseDto();
                var rendeles = new Rendeles
                {
                    Asztalszam = addRendelesDto.AsztalSzam,
                    Fizetesimod = addRendelesDto.Fizetesimod
                };
                if (rendeles != null) {
                    await _context.Rendeles.AddAsync(rendeles);
                    await _context.SaveChangesAsync();
                    result.Message = "Sikeres rendelés létrehozás";
                    result.result = rendeles;
                    return result;
                }
                result.Message = "Sikertelen rendelés létrehozás";
                result.result = rendeles;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<object> GettAllRendeles()
        {
            try
            {
                var result = new ResultResponseDto();
                result.Message = "Sikeres rendelés lekérdezés";
                result.result = _context.Rendeles.ToList();
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
