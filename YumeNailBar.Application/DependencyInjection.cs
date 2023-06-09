﻿using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Application.Customers.Commands.CreateCustomerCommand;
using YumeNailBar.Application.Customers.Queries.GetAllCustomers;
using YumeNailBar.Application.Customers.Queries.GetCustomerById;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;

namespace YumeNailBar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateCustomerCommand, Result<Customer>>, CreateCustomerCommandHandler>();
        services.AddScoped<IRequestHandler<GetCustomerByIdQuery, CustomerDto>, GetCustomerByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>, GetAllCustomersQueryHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
        //services.AddAutoMapper(typeof(CustomerMappingProfile));
        return services;
    }
}