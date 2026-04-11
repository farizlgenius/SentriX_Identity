using System;
using Identity.Domain.Enums;

namespace Identity.Application.DTOs;

public record UpdateOperatorDto(
  int Id,
  string OperatorId,
  string Username,
  Title title,
  string Firstname,
  string Middlename,
  string Lastname,
  Gender Gender,
  string Email,
  string Mobile,
  int RoleId,
  List<int> LocationId
  );