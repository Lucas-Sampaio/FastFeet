﻿using FastFeet.API.Application.Commands.DestinatarioCommands;
using FastFeet.API.Application.Commands.EntregadorCommands;
using FastFeet.API.Mediator;
using FastFeet.Dominio.AggregatesModel.DestinatarioAggregate;
using FastFeet.Dominio.AggregatesModel.EntregadorAggregate;
using FastFeet.Infra.Repositories;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FastFeet.API.Configuration
{
    public static class DependecyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //command
            services.AddScoped<IRequestHandler<CadastrarDestinatarioCommand, ValidationResult>, DestinatarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarDestinatarioCommand, ValidationResult>, DestinatarioCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarEntregadorCommand, ValidationResult>, EntregadorCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarEntregadorCommand, ValidationResult>, EntregadorCommandHandler>();
            //data
            services.AddScoped<IDestinatarioRepository, DestinatarioRepository>();
            services.AddScoped<IEntregadorRepository, EntregadorRepository>();

        }
    }
}
