﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace IAS.Application.Behaviours
{
  public class UnHandledExceptionsBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
  {
    private readonly ILogger<TRequest> _logger;

    public UnHandledExceptionsBehaviour(ILogger<TRequest> logger)
    {
      _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
      try
      {
        return await next();
      }
      catch (Exception ex)
      {
        var requestName = typeof(TRequest).Name;
        _logger.LogError(ex, "Application Request: Sucedió una excepción para el request {Name} {@Request}", requestName, request);
        throw;
      }
    }
  }
}