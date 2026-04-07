using System;
using System.Net;

namespace Identity.Application.DTOs;

public record MeDto(HttpStatusCode Code, string Message, DateTime Timestamp, List<int> Locations, List<PermissionDto> Permissions) : BaseDto(Code, Message, Timestamp);
