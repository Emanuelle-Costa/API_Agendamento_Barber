using System;
using System.Threading.Tasks;
using BarberShop.Models;
namespace BarberShop.Models.Contratos
{
    public interface IProfissionalModel
    {
        Task<Profissional> AdicionarProfissional(Profissional model);
        Task<Profissional> AtualizarProfissional(int profissionalId, Profissional model);
        Task<bool> ApagarProfissional(int profissionalId);


        Task<Profissional[]> PegarTodosProfissionais(bool incluirClientes = false, bool incluirServicos = false);
        Task<Profissional[]> PegarTodosProfissionaisPeloNome(string nome, bool incluirClientes = false, bool incluirServicos = false); 
        Task<Profissional> PegarProfissionalPeloId(int profissionalId,  bool incluirClientes = false, bool incluirServicos = false);

    }
}