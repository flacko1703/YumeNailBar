using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Application.DTO;
using YumeNailBar.Application.Registration.Commands.CancelRegistrationCommand;
using YumeNailBar.Application.Registration.Commands.CreateClientCommand;
using YumeNailBar.Application.Registration.Commands.CreateRegistrationCommand;
using YumeNailBar.Application.Registration.Queries.GetClientByRegistrationId;
using YumeNailBar.Application.Registration.Queries.GetRegistrationById;
using YumeNailBar.Application.Services;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.Repositories;

namespace YumeNailBar.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CreateClientCommand, Result>, CreateClientCommandHandler>();
        services.AddScoped<IRequestHandler<CancelRegistrationCommand, Result>, CancelRegistrationCommandHandler>();
        services.AddScoped<IRequestHandler<CreateRegistrationCommand, Result>, CreateRegistrationCommandHandler>();
        services.AddScoped<IRequestHandler<GetRegistrationByIdQuery, Result<RegistrationDto>>, GetRegistrationByIdQueryHandler>();
        services.AddScoped<IQueryHandler<GetClientByPhoneNumberQuery, Client>, GetClientByPhoneNumberQueryHandler>();
        services.AddScoped<IRegistrationSearchService, RegistrationSearchService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>());
        return services;
    }
}