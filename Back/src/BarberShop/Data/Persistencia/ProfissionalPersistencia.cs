
using BarberShop.Data.Contratos;
using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class ProfissionalPersistencia : IProfissionalPersistencia
    {
        private readonly ContextoBanco _context;

        public ProfissionalPersistencia(ContextoBanco context)
        {
            _context = context;

        }
         public async Task<Profissional[]> PegarTodosProfissionais(bool incluirClientes = false, bool incluirServicos = false)
        {
            IQueryable<Profissional> consulta = _context.Profissionais
                .Include(p => p.Servicos)
                .Include(p => p.Agendas);

            if(incluirClientes)
            {
                consulta = consulta.Include(p => p.ClientesProfissionais)
                                   .ThenInclude(cp => cp.Cliente)
                                   .Include(p => p.ServicosProfissionais)
                                   .ThenInclude(sp => sp.Servico);
            }
            
            consulta = consulta.AsNoTracking().OrderBy(p => p.Nome);

            return await consulta.ToArrayAsync();
        }

         public async Task<Profissional[]> PegarTodosProfissionaisPeloNome(string nome, bool incluirClientes = false, bool incluirServicos = false)
        {
            IQueryable<Profissional> consulta = _context.Profissionais
                .Include(p => p.Servicos)
                .Include(p => p.Agendas);

            if(incluirClientes)
            {
                consulta = consulta.Include(p => p.ClientesProfissionais)
                                   .ThenInclude(cp => cp.Cliente)
                                   .Include(p => p.ServicosProfissionais)
                                   .ThenInclude(sp => sp.Servico);
            }
            
            consulta = consulta.AsNoTracking().OrderBy(p => p.Nome)
                               .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await consulta.ToArrayAsync();
        }

        public async Task<Profissional> PegarProfissionalPeloId(Guid profissionalId, bool incluirClientes = false, bool incluirServicos = false)
        {
            IQueryable<Profissional> consulta = _context.Profissionais
                .Include(p => p.Servicos)
                .Include(p => p.Agendas);

            if(incluirClientes)
            {
                consulta = consulta.Include(p => p.ClientesProfissionais)
                                   .ThenInclude(cp => cp.Cliente)
                                   .Include(p => p.ServicosProfissionais)
                                   .ThenInclude(sp => sp.Servico);
            }
            
            consulta = consulta.AsNoTracking().OrderBy(p => p.Id)
                               .Where(p => p.Id == profissionalId);

            return await consulta.FirstOrDefaultAsync();
        }       
    }
}