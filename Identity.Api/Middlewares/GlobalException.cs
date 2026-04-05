using System;

namespace Identity.Api.Middlewares;

public sealed class GlobalException : IMiddleware
{
  public Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    throw new NotImplementedException();
  }
}
