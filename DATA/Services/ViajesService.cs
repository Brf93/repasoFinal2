using repasoFinal2.DATA.Models;
using repasoFinal2.DATA.Repositories;

namespace repasoFinal2.DATA.Services
{
    public class ViajesService : IViajesService
    {
        private IViajeRepository _repo;
        public ViajesService(IViajeRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ModificarFecha(int id, DateOnly fecha)
        {
            var entity = await TraerID(id);
            if (fecha > entity.FechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser mayor a la fecha de fin");
            }

            return await _repo.UpdateFecha(entity,fecha);
        }

        public async Task<List<Viaje>> TraerEstado(string estado)
        {
            return await _repo.GetEstado(estado);
        }

        public async Task<Viaje?> TraerID(int id)
        {
            var entity = await _repo.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("El ID no existe");
            }
            return entity;
        }
        public async Task<List<Viaje>> TraerTodo()
        {
            return await _repo.GetAll();
        }
    }
}
