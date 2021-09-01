using Domain;
using Domain.Classes;
using Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Domain
{
    public class UnitOfWork:IUnitOfWork
    {

        private readonly DbContext _dbContext;
        private IRepository<RefType> _refTypes;
        private IRepository<ObjectClass> _objectClasses;
        private IRepository<AreaChanging> _areaChangings;
        public UnitOfWork(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<RefType> RefTypes => _refTypes ??= new Repository<RefType>(_dbContext);
        public IRepository<ObjectClass> ObjectClasses => _objectClasses ??= new Repository<ObjectClass>(_dbContext);
        public IRepository<AreaChanging> AreaChangings => _areaChangings ??= new Repository<AreaChanging>(_dbContext);
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

       
    }
}
