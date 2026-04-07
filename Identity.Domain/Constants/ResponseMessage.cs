using System;

namespace Identity.Domain.Constants;

public class ResponseMessage
{
  public const string InternalServerError = "An unexpected error occurred. Please try again later.";
  public const string BadRequest = "The request was invalid. Please check the data and try again.";
  public const string NotFound = "The requested resource was not found.";
  public const string Unauthorized = "You are not authorized to access this resource.";
  public const string Forbidden = "You do not have permission to access this resource.";

}
