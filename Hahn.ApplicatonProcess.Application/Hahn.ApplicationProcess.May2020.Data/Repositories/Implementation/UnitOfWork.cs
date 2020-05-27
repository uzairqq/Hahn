using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces;

namespace Hahn.ApplicationProcess.May2020.Data.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HahnDbContext _databaseContext;
        private IApplicantRepository _authorRepository;
        //private IRepository<Book> _bookRepository;
        public UnitOfWork(HahnDbContext databaseContext)
        { _databaseContext = databaseContext; }

        public IApplicantRepository ApplicantRepository
        {
            get { return _authorRepository = _authorRepository ?? new ApplicantRepository(_databaseContext); }
        }

        //public IRepository<Book> BookRepository
        //{
        //    get { return _bookRepository = _bookRepository ?? new Repository<Book>(_databaseContext); }
        //}

        public void Commit()
        { _databaseContext.SaveChanges(); }

        public void Rollback()
        { _databaseContext.Dispose(); }
    }
}
