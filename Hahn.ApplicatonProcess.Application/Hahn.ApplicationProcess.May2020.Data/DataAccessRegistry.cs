using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicationProcess.May2020.Data.Repositories.Implementation;
using Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.May2020.Data
{
   public class DataAccessRegistry
    {
        public static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IApplicantRepository), typeof(ApplicantRepository));

        }
    }
}
