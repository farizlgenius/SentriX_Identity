using System;
using System.Net;

namespace Identity.Application.DTOs;

public sealed record TokenDto(
  HttpStatusCode Code,
  string Message,
  DateTime Timestamp,
  string AccessToken,
  string RefreshToken,
  int ExpireInMinute
) : BaseDto(Code, Message, Timestamp);
