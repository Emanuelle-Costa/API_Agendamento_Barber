namespace BarberShop.Data.Contratos
{
    public interface IGeralPersistencia
    {
        void Adicionar<Dados>(Dados entidade) where Dados : class;
        void Atualizar<Dados>(Dados entidade) where Dados : class;
        void Apagar<Dados>(Dados entidade) where Dados : class;
        void ApagarVarios<Dados>(Dados[] entidade) where Dados : class;
        Task<bool> SalvarAlteracoes();

    }
}