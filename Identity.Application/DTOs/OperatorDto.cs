using System;
using System.Net;
using Identity.Domain.Enums;

namespace Identity.Application.DTOs;

public sealed record OperatorDto(
  int Id,
  string UserId,
  string Username,
  Title Title,
  string FirstName,
  string MiddleName,
  string LastName,
  Gender Gender,
  string Email,
  string Mobile,
  string Role
);
