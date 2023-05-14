using FluentResults;
using MediatR;

namespace YumeNailBar.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
    
}