namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaracion o matricula de nuestras interfaces de repositorios
        ICategoryRespository Category { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
