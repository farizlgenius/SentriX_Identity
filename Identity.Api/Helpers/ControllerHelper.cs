using System;
using System.Net;
using Identity.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Helpers;

public static class ControllerHelper
{
  public static IActionResult FromStatusCode<T>(this ControllerBase controller, T response)
        where T : BaseDto
  {
    return response.Code switch
    {
      HttpStatusCode.OK => controller.Ok(response),
      HttpStatusCode.BadRequest => controller.BadRequest(response),
      HttpStatusCode.NotFound => controller.NotFound(response),
      HttpStatusCode.Unauthorized => controller.Unauthorized(response),
      HttpStatusCode.Forbidden => controller.Forbid(response.ToString()),
      _ => controller.StatusCode(StatusCodes.Status500InternalServerError, response)
    };
  }

}