using repasoFinal2.DATA.Models;

namespace repasoFinal2.DATA.Services
{
    public interface IViajesService
    {

        Task<List<Viaje>> TraerTodo();
        Task<List<Viaje>> TraerEstado(string estado);
        Task<Viaje?> TraerID(int id);
        Task<bool> ModificarFecha(int id, DateOnly fecha);
    }
}
