using System;
using Hahn.ApplicationProcess.May2020.Domain.Services.Implementation;
using Hahn.ApplicationProcess.May2020.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.May2020.Domain
{
    public class ComponentAccessRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IApplicantService), typeof(ApplicantService));

        }
    }
}
