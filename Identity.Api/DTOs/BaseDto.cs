using System;
using System.Net;

namespace Identity.Api.DTOs;

public record BaseDto(HttpStatusCode Code, string Message, DateTime Timestamp);