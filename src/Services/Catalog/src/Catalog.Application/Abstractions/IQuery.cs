using Catalog.Domain;
using MediatR;

namespace Catalog.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
