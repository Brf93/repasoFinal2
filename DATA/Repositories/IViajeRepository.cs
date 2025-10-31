using repasoFinal2.DATA.Models;

namespace repasoFinal2.DATA.Repositories
{
    public interface IViajeRepository
    {
        Task<List<Viaje>> GetAll();
        Task<List<Viaje>> GetEstado(string estado);
        Task<Viaje?> GetById(int id);
        Task<bool> UpdateFecha(Viaje viaje,DateOnly fecha);
    }
}
