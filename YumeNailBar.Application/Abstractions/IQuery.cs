using FluentResults;
using MediatR;

namespace YumeNailBar.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}