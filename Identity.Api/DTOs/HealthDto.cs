using System.Net;

namespace Identity.Api.DTOs;

public sealed record HealthDto(HttpStatusCode Code, string Message, DateTime Timestamp) : BaseDto(Code, Message, Timestamp);
