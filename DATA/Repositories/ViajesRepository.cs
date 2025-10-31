using Microsoft.EntityFrameworkCore;
using repasoFinal2.DATA.Models;

namespace repasoFinal2.DATA.Repositories
{
    public class ViajesRepository : IViajeRepository
    {
        private ViajesContext _context;
        public ViajesRepository(ViajesContext context)
        {
            _context = context;
        }

        public async Task<List<Viaje>> GetAll()
        {
            return await _context.Viajes.Where(x => x.PrecioTotal > 100000).ToListAsync(); 
        }

        public async Task<Viaje?> GetById(int id)
        {
            return await _context.Viajes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Viaje>> GetEstado(string estado)
        {
            return await _context.Viajes.Where(x => x.Estado == estado).ToListAsync();
        }

        public async Task<bool> UpdateFecha(Viaje viaje, DateOnly fecha)
        {
            viaje.FechaInicio = fecha;
            _context.Update(viaje);
            return await _context.SaveChangesAsync()> 0;
        }
    }
}
