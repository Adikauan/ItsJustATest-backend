using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ISampleRepository SampleRepository { get; }
        Task<bool> Commit();
        void Rollback();
    }
}
