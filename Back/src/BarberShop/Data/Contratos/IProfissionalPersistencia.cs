
using System;
using System.Threading.Tasks;
using BarberShop.Models;

namespace BarberShop.Data.Contratos
{
    public interface IProfissionalPersistencia
    {
        Task<Profissional[]> PegarTodosProfissionaisPeloNome(string nome, bool incluirClientes = false, bool incluirServicos = false);
        Task<Profissional[]> PegarTodosProfissionais(bool incluirClientes = false, bool incluirServicos = false);
        Task<Profissional> PegarProfissionalPeloId(Guid profissionalId,  bool incluirClientes = false, bool incluirServicos = false);

    }
}