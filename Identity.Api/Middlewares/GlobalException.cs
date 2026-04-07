using System;
using Identity.Application.DTOs;
using Identity.Domain.Constants;

namespace Identity.Api.Middlewares;

public sealed class GlobalException : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (Exception ex)
    {
      await HandleException(context, ex);
    }
  }

  private Task HandleException(HttpContext context, Exception ex)
  {
    // Log the exception (you can use a logging framework here)
    Console.WriteLine($"An error occurred: {ex.Message}");

    // Set the response status code and content
    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Response.ContentType = "application/json";

    var response = new BaseDto(System.Net.HttpStatusCode.InternalServerError, ex.Message, DateTime.UtcNow);
    return context.Response.WriteAsJsonAsync(response);
  }
}
