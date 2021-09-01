
using Domain.Classes;

namespace Infrastructure.Domain
{
    public interface IUnitOfWork
    {
        IRepository<RefType> RefTypes { get; }

        IRepository<ObjectClass> ObjectClasses { get; }
        IRepository<AreaChanging> AreaChangings { get; }
        void Commit();
    }
}
