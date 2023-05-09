using MediatR;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Application.RegistrationInfo.Commands.CreateRegistrationCommand;

public record CreateRegistrationCommand(Guid Id, ClientWriteModel Client, AppointmentDate AppointmentDate,
        bool IsCanceled) : IRequest;

public record ClientWriteModel(ClientName ClientName, PhoneNumber PhoneNumber, LinkedList<Procedure> Procedures,
    string Comment);