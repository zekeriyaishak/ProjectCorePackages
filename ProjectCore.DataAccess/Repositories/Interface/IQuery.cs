using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.DataAccess.Repositories.Interface
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
