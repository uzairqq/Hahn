using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IApplicantRepository ApplicantRepository { get; }
        void Commit();
        void Rollback();
    }
}
