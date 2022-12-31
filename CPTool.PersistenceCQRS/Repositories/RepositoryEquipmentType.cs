

using Microsoft.EntityFrameworkCore;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryEquipmentType : CommandRepository<EquipmentType>, IRepositoryEquipmentType
    {
       

        public RepositoryEquipmentType(TableContext dbcontext) : base(dbcontext)
        {
           
        }
       
    }
}
