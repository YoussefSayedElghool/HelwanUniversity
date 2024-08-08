using HelwanUniversity.Core.Contracts.Repositories;
using HelwanUniversity.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelwanUniversity.Core.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }

        Response<bool> Save();
    }
}
