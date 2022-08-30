using Loto3000.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto3000.DataAccess.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
    }
}
