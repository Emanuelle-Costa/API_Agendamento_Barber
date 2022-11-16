
using BarberShop.Data.Contratos;
using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class ClientePersistencia : IClientePersistencia
    {
        private readonly ContextoBanco _context;

        public ClientePersistencia(ContextoBanco context)
        {
            _context = context;

        }
        public async Task<Cliente[]> PegarTodosClientes(bool incluirProfissionais = false)
        {
            IQueryable<Cliente> consulta = _context.Clientes
                .Include(c => c.Agendas);

            if(incluirProfissionais)
            {
                consulta = consulta.Include(c => c.ClientesProfissionais)
                                   .ThenInclude(cp => cp.Cliente);
                                   
            }
            
            consulta = consulta.AsNoTracking().OrderBy(c => c.Nome);

            return await consulta.ToArrayAsync();
        }

        public async Task<Cliente[]> PegarTodosClientesPeloNome(string nome, bool incluirProfissionais = false)
        {
             IQueryable<Cliente> consulta = _context.Clientes
                .Include(c => c.Agendas);

            if(incluirProfissionais)
            {
                consulta = consulta.Include(c => c.ClientesProfissionais)
                                   .ThenInclude(cp => cp.Cliente);
                                   
            }
            
            consulta = consulta.AsNoTracking().OrderBy(c => c.Nome)
                                .Where(c => c.Nome.ToLower().Contains(nome.ToLower()));

            return await consulta.ToArrayAsync();
        }

        public async Task<Cliente> PegarClientePeloId(Guid clienteId, bool incluirProfissionais)
        {
            IQueryable<Cliente> consulta = _context.Clientes
                .Include(c => c.Agendas);

            if(incluirProfissionais)
            {
                consulta = consulta.Include(c => c.ClientesProfissionais)
                                   .ThenInclude(cp => cp.Cliente);
                                   
            }
            
            consulta = consulta.AsNoTracking().OrderBy(c => c.Id)
                               .Where(c => c.Id == clienteId);

            return await consulta.FirstOrDefaultAsync();
        }
         
    }
}