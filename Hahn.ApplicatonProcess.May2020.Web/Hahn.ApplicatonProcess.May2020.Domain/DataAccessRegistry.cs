using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Repositories.Implementation;
using Hahn.ApplicatonProcess.May2020.Domain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Domain
{
    public class DataAccessRegistry
    {
        public static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IApplicantRepository), typeof(ApplicantRepository));
        }
    }
}
