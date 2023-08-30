using Catalog.Domain;
using MediatR;

namespace Catalog.Application.Abstractions;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result<Unit>>
    where TCommand : ICommand { }

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse> { }
