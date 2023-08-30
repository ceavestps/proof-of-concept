using Catalog.Domain;
using MediatR;

namespace Catalog.Application.Abstractions;

public interface ICommand : IRequest<Result<Unit>> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
