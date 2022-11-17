using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Data.Contratos;
using BarberShop.Models.Contratos;

namespace BarberShop.Models
{
    public class ProfissionalModel : IProfissionalModel
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IProfissionalPersistencia _profissionalPersistencia;

        public ProfissionalModel(IGeralPersistencia geralPersistencia, IProfissionalPersistencia profissionalPersistencia)
        {
            _profissionalPersistencia = profissionalPersistencia;
            _geralPersistencia = geralPersistencia;
            
        }

        public async Task<Profissional> AdicionarProfissional(Profissional model)
        {
            try
            {
                _geralPersistencia.Adicionar<Profissional>(model);
                if(await _geralPersistencia.SalvarAlteracoes())
                {
                    return await _profissionalPersistencia.PegarProfissionalPeloId(model.Id, false);
                }
                return null;
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
        }

        public async Task<Profissional> AtualizarProfissional(int profissionalId, Profissional model)
        {
            try
            {
                var profissional = await _profissionalPersistencia.PegarProfissionalPeloId(profissionalId, false);
                if (profissional == null) return null;

                model.Id = profissional.Id;

                _geralPersistencia.Atualizar(model);
                if (await _geralPersistencia.SalvarAlteracoes())
                {
                    return await _profissionalPersistencia.PegarProfissionalPeloId(model.Id, false);
                }
                return null;
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
        }

        public async Task<bool> ApagarProfissional(int profissionalId)
        {
            try
            {
                var profissional = await _profissionalPersistencia.PegarProfissionalPeloId(profissionalId, false);
                if (profissional == null) throw new Exception("Profissional não encontrado!");

                _geralPersistencia.Apagar<Profissional>(profissional);
                return await _geralPersistencia.SalvarAlteracoes();
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
        }

        public async Task<Profissional[]> PegarTodosProfissionais(bool incluirClientes = false, bool incluirServicos = false)
        {
           try
           {
                var profissionais = await _profissionalPersistencia.PegarTodosProfissionais(incluirClientes, incluirServicos);
                if(PegarTodosProfissionais == null) return null;

                return profissionais;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Profissional[]> PegarTodosProfissionaisPeloNome(string nome, bool incluirClientes = false, bool incluirServicos = false)
        {
            try
           {
                var profissionais = await _profissionalPersistencia.PegarTodosProfissionaisPeloNome(nome, incluirClientes, incluirServicos);
                if(PegarTodosProfissionais == null) return null;

                return profissionais;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Profissional> PegarProfissionalPeloId(int profissionalId, bool incluirClientes = false, bool incluirServicos = false)
        {
           try
           {
                var profissionais = await _profissionalPersistencia.PegarProfissionalPeloId(profissionalId, incluirClientes, incluirServicos);
                if(PegarTodosProfissionais == null) return null;

                return profissionais;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

    }
}