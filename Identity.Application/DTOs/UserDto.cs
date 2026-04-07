using System;
using System.Net;

namespace Identity.Application.DTOs;

public sealed record UserDto(
  HttpStatusCode Code,
  string Message,
  DateTime Timestamp,
  string UserId,
  string Username,
  string FirstName,
  string MiddleName,
  string LastName,
  string Email,
  string Mobile
) : BaseDto(
  Code,
  Message,
  Timestamp
);
