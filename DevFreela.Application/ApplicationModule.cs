using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Commands.InsertSkill;
using DevFreela.Application.Commands.InsertUser;
using DevFreela.Application.Commands.InsertUserSkills;
using DevFreela.Application.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers()
                .AddValidation();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            // Registrar todos os handlers de comandos numa única chamada ao AddMediatR
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>();
                config.RegisterServicesFromAssemblyContaining<InsertUserCommand>();
                config.RegisterServicesFromAssemblyContaining<InsertSkillCommand>();
                config.RegisterServicesFromAssemblyContaining<InsertUserSkillsCommand>();
            });

            // Registro de comportamentos (Behaviors) do MediatR
            services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertProjectCommand>();
            return services;
        }
    }
}
