﻿using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;
using YumeNailBar.Application.Customers.Queries.GetRegistrationById;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateCustomerCommand, Result>, CreateCustomerCommandHandler>();
        services.AddScoped<IRequestHandler<GetCustomerByIdQuery, Result<RegistrationDto>>, GetCustomerByIdQueryHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
        services.AddAutoMapper(typeof(CustomerMappingProfile), typeof(ProcedureMappingProfile), typeof(RegistrationMappingProfile));
        return services;
    }
}