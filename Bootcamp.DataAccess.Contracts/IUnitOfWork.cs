using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
