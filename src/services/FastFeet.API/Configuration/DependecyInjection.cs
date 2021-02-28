using FastFeet.API.Application.Commands.DestinatarioCommands;
using FastFeet.API.Mediator;
using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Infra.Repositories;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FastFeet.API.Configuration
{
    public static class DependecyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //api
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IAspNetUser, AspNetUser>();

            //application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //command
            services.AddScoped<IRequestHandler<CadastrarDestinatarioCommand, ValidationResult>, DestinatarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarDestinatarioCommand, ValidationResult>, DestinatarioCommandHandler>();

            //data
            services.AddScoped<IDestinatarioRepository, DestinatarioRepository>();

        }
    }
}
