using System;
using System.Net;

namespace Identity.Application.DTOs;

public sealed record TokenDto(
  string AccessToken,
  string RefreshToken,
  int ExpireInMinute
);
