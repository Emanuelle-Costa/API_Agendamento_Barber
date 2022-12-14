using BarberShop.Models;

namespace BarberShop.Data.Contratos
{
    public interface IClientePersistencia
    {
        Task<Cliente[]> PegarTodosClientesPeloNome(string nome, bool incluirProfissionais);
        Task<Cliente[]> PegarTodosClientes(bool incluirProfissionais);
        Task<Cliente> PegarClientePeloId(int clienteId, bool incluirProfissionais);
    }
}