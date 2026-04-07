using System.Net;

namespace Identity.Application.DTOs;

public record BaseDto(HttpStatusCode Code, string Message, DateTime Timestamp);