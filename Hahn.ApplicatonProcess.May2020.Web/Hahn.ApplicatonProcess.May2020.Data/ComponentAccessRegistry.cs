using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Data.Services.Implementation;
using Hahn.ApplicatonProcess.May2020.Data.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.May2020.Data
{
   public class ComponentAccessRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IApplicantServices), typeof(ApplicantServices));
        }
    }
}
