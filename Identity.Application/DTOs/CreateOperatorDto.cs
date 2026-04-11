using Identity.Domain.Enums;

namespace Identity.Application.DTOs;

public record CreateOperatorDto(
  string OperatorId,
  string Username,
  string Password,
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
