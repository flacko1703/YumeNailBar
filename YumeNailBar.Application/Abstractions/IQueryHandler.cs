using FluentResults;
using MediatR;

namespace YumeNailBar.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}