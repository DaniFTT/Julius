using Ardalis.Result;
using MediatR;

namespace Julius.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : 
    IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}

